using LastBeer.Back.Models;

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
        User GetUserWithAllData(int id);
        bool InsertUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool UserExists(string userName);
        bool UserExistsById(int userId);
        bool Save();
    }
}
