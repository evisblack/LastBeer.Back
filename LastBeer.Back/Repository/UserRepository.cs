using LastBeer.Back.Data;
using LastBeer.Back.Models;
using LastBeer.Back.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LastBeer.Back.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool DeleteUser(User user)
        {
            _dbContext.Users.Remove(user);
            return Save();
        }

        public User GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public ICollection<User> GetUsers()
        {
            return _dbContext.Users
        .Include(u => u.Favorites)
            .ThenInclude(f => f.Bar) // Esto carga la información del bar dentro de los favoritos
        .OrderBy(u => u.Name)
        .ToList();
        }

        public bool InsertUser(User user)
        {
            //user.Password = HashPassword(user.Password);
            _dbContext.Users.Add(user);
            return Save();
        }

        public User GetUserWithFavouriteBars(int id)
        {
            return _dbContext.Users
                .Include(u => u.Favorites)
                .FirstOrDefault(u => u.Id == id);
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
            bool exists = _dbContext.Users.Any(u => u.UserName.ToLower().Trim() == userName.ToLower().Trim());
            return exists;
        }
        public bool UserExistsById(int userId)
        {
            return _dbContext.Users.Any(u => u.Id == userId);
        }
    }
}
