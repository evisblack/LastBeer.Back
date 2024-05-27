using LastBeer.Back.Models;

namespace LastBeer.Back.Repository.IRepository
{
    public interface IGameRepository
    {
        Game GetGame(int gameId);
        ICollection<Game> GetGames();
        bool AddGame(Game game);
        bool UpdateGame(Game game);
        bool DeleteGame(int gameId);
        bool Save();   
    }
}
