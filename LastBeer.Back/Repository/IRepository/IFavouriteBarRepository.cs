using LastBeer.Back.Models;

namespace LastBeer.Back.Repository.IRepository
{
    public interface IFavouriteBarRepository
    {
        bool AddFavouriteBar(int userId, Bar bar);
        bool RemoveFavouriteBar(int userId, string placeId);
        ICollection<FavouriteBar> GetFavouriteBarsByUserId(int userId);
    }
}
