using LastBeer.Back.Models;

namespace LastBeer.Back.Repository.IRepository
{
    public interface IScoreRepository
    {
        ICollection<Score> GetScoresByUserId(int userId);
        ICollection<Score> GetScoresByUserIdAndGameId(int userId, int gameId);
        bool AddScore(Score score);
        bool Save();
    }
}
