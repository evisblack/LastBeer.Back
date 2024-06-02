using LastBeer.Back.Data;
using LastBeer.Back.Models;
using LastBeer.Back.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LastBeer.Back.Repository
{
    public class FavouriteBarRepository : IFavouriteBarRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IBarRepository _barRepository;

        public FavouriteBarRepository(AppDbContext dbContext, IBarRepository barRepository)
        {
            _dbContext = dbContext;
            _barRepository = barRepository;
        }

        public bool AddFavouriteBar(int userId, Bar bar)
        {
            // Comprobamos que el bar no existe en la base de datos
            var existingBar = _barRepository.GetByPlaceId(bar.PlaceId);
            if (existingBar == null)
            {
                // si no existe lo añadimos a la tabla Bar
                _barRepository.AddBar(bar);
                existingBar = bar; 
            }

            // Se comprueba si esta relación ya existe
            var favouriteExists = _dbContext.FavouriteBars.Any(fb => fb.UserId == userId && fb.BarId == existingBar.Id);
            if (!favouriteExists)
            {
                // Si no existe se añade
                var favouriteBar = new FavouriteBar
                {
                    UserId = userId,
                    BarId = existingBar.Id
                };
                _dbContext.FavouriteBars.Add(favouriteBar);
                return _dbContext.SaveChanges() > 0;
            }

            return false;
        }

        public bool RemoveFavouriteBar(int userId, string placeId)
        {
            var existingBar = _barRepository.GetByPlaceId(placeId);
            if (existingBar != null)
            {
                var favouriteBar = _dbContext.FavouriteBars.FirstOrDefault(fb => fb.UserId == userId && fb.BarId == existingBar.Id);
                if (favouriteBar != null)
                {
                    _dbContext.FavouriteBars.Remove(favouriteBar);
                    return _dbContext.SaveChanges() > 0;
                }
            }
                
            return false;
        }

        public ICollection<FavouriteBar> GetFavouriteBarsByUserId(int userId)
        {
            return _dbContext.FavouriteBars
                .Where(fb => fb.UserId == userId)
                .Include(fb => fb.Bar)
                .ToList();
        }
    }


}
