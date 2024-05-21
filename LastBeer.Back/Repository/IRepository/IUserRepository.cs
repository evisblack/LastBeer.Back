using LastBeer.Back.Models;
using LastBeer.Back.Models.Dtos.UserDtos;

namespace LastBeer.Back.Repository.IRepository
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetById(int id);
        ICollection<User> GetUserByUserName(string userName);
        User GetUserWithFavouriteBars(int id);
        User GetUserWithVisitedBars(int id);
        User GetUserWithScores(int id);
        List<int> GetUserGameWithScores(int userId, int gameId);
        User GetUserWithAllData(int id);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool UserExists(string userName);
        bool UserExistsById(int userId);
        Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto);
        Task<User> Registration(UserInsertDto userInsertDto);
        bool Save();
    }
}
