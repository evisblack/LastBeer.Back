using LastBeer.Back.Data;
using LastBeer.Back.Models;
using LastBeer.Back.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LastBeer.Back.Repository
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly AppDbContext _dbContext;

        public ScoreRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Score> GetScoresByUserId(int userId)
        {
            return _dbContext.Scores
                .Include(s => s.Game)
                .Where(s => s.UserId == userId)
                .ToList();
        }

        public ICollection<Score> GetScoresByUserIdAndGameId(int userId, int gameId)
        {
            return _dbContext.Scores
                .Where(s => s.UserId == userId && s.GameId == gameId)
                .ToList();
        }

        public bool AddScore(Score score)
        {
            _dbContext.Scores.Add(score);
            return Save();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0;
        }
    }
}
