using LastBeer.Back.Data;
using LastBeer.Back.Models;
using LastBeer.Back.Repository.IRepository;

namespace LastBeer.Back.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _dbContext;

        public GameRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Game GetGame(int gameId)
        {
            return _dbContext.Games.FirstOrDefault(g => g.Id == gameId);
        }

        public ICollection<Game> GetGames()
        {
            return _dbContext.Games.ToList();
        }

        public bool AddGame(Game game)
        {
            _dbContext.Games.Add(game);
            return Save();
        }

        public bool UpdateGame(Game game)
        {
            _dbContext.Games.Update(game);
            return Save();
        }

        public bool DeleteGame(int gameId)
        {
            var game = _dbContext.Games.FirstOrDefault(g => g.Id == gameId);
            if (game != null)
            {
                _dbContext.Games.Remove(game);
                return Save();
            }
            return false;
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0;
        }
    }
}
