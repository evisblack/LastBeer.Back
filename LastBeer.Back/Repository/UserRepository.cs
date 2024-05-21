using LastBeer.Back.Data;
using LastBeer.Back.Models;
using LastBeer.Back.Models.Dtos.UserDtos;
using LastBeer.Back.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;

namespace LastBeer.Back.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private string secretKey;
        public UserRepository(AppDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            secretKey = config.GetValue<string>("ApiSettings:Secret");
        }

        public User GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public ICollection<User> GetUsers()
        {
            return _dbContext.Users
                .OrderBy(u => u.Name)
                .ToList();
        }

        public User GetUserWithFavouriteBars(int id)
        {
            return _dbContext.Users
                .Where(u => u.Id == id)
                .Include(u => u.Favorites)
                    .ThenInclude(f => f.Bar) // Esto carga la información del bar dentro de los favoritos
                .FirstOrDefault();
        }

        public User GetUserWithVisitedBars(int id)
        {
            return _dbContext.Users
                .Where(u => u.Id == id)
                .Include(u => u.VisitedBars)
                    .ThenInclude(f => f.Bar)
                .FirstOrDefault();
        }

        public User GetUserWithScores(int id)
        {
            return _dbContext.Users
                .Where(u => u.Id == id)
                .Include(u => u.Scores)
                    .ThenInclude(f => f.Game)
                .FirstOrDefault();
        }
        public List<int> GetUserGameWithScores(int userId, int gameId)
        {
            return _dbContext.Scores
                .Where(p => p.UserId == userId && p.GameId == gameId)
                .Select(p => p.Points)
                .ToList();

        }


        public User GetUserWithAllData(int id)
        {
            return _dbContext.Users
                .Where(u => u.Id == id)
                .Include(u => u.Favorites)
                    .ThenInclude(f => f.Bar)
                .Include(u => u.VisitedBars)
                    .ThenInclude(f => f.Bar)
                .Include(u => u.Scores)
                    .ThenInclude(f => f.Game)
                .FirstOrDefault();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            return Save();
        }

        public ICollection<User> GetUserByUserName(string userName)
        {
            return _dbContext.Users
                .Where(x => x.UserName.Contains(userName))
                .ToList();
        }

        public bool UserExists(string userName)
        {
            var userNameDb = _dbContext.Users.FirstOrDefault(u => u.UserName == userName);
            if(userNameDb == null)
            {
                return false;   
            }
            return true;
        }
        public bool UserExistsById(int userId)
        {
            return _dbContext.Users.Any(u => u.Id == userId);
        }

        public bool DeleteUser(User user)
        {
            _dbContext.Users.Remove(user);
            return Save();
        }

        public async Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto)
        {
            var encryptedPassword = Getmd5(userLoginDto.Password);

            var user =  _dbContext.Users.FirstOrDefault(
                u => u.UserName.ToLower() == userLoginDto.UserName.ToLower()
                && u.Password == encryptedPassword
                );
            if (user == null)
            {
                return new UserLoginResponseDto()
                {
                    Token = "",
                    User = null
                };
            }

            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenhandler.CreateToken(tokenDescriptor);

            UserLoginResponseDto userLoginResponseDto = new UserLoginResponseDto()
            {
                Token = tokenhandler.WriteToken(token),
                User = user
            };

            return userLoginResponseDto;
        }

        public async Task<User> Registration(UserInsertDto userInsertDto)
        {
            var encryptedPassword = Getmd5(userInsertDto.Password);
            User user = new User()
            {
                UserName = userInsertDto.UserName,
                Password = encryptedPassword,
                Email = userInsertDto.Email,
                Name = userInsertDto.Name,
                LastName = userInsertDto.LastName,
                PhoneNumber = userInsertDto.PhoneNumber,
                Address = userInsertDto.Address,
                Role = userInsertDto.Role
            };
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            user.Password = encryptedPassword;
            return user;
        }


        //Metodo para encriptar contraseña con MD5
        public static string Getmd5(string input)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(input);
            data = x.ComputeHash(data);
            string resp = "";
            for (int i =0; i < data.Length; i++)
                resp += data[i].ToString("x2").ToLower();
            return resp;
        }
    }
}
