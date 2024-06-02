using LastBeer.Back.Data;
using LastBeer.Back.Models;
using LastBeer.Back.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LastBeer.Back.Repository
{
    public class VisitedBarRepository : IVisitedBarRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IBarRepository _barRepository;

        public VisitedBarRepository(AppDbContext dbContext, IBarRepository barRepository)
        {
            _dbContext = dbContext;
            _barRepository = barRepository;
        }

        public bool AddOrUpdateVisitedBar(int userId, Bar bar)
        {
            // Check if the bar already exists in the database using the bar repository
            var existingBar = _barRepository.GetByPlaceId(bar.PlaceId);
            if (existingBar == null)
            {
                // If the bar does not exist, add it to the Bars table using the bar repository
                _barRepository.AddBar(bar);
                existingBar = bar; // Set the existing bar to the newly added bar
            }

            // Check if the visited relation already exists
            var visitedBar = _dbContext.VisitedBars.FirstOrDefault(vb => vb.UserId == userId && vb.BarId == existingBar.Id);
            if (visitedBar == null)
            {
                // Add the visited relation
                visitedBar = new VisitedBar
                {
                    UserId = userId,
                    BarId = existingBar.Id,
                    VisitedDate = DateTime.UtcNow  // Set the visit date to now
                };
                _dbContext.VisitedBars.Add(visitedBar);
            }
            else
            {
                // Update the visited date if the relation already exists
                visitedBar.VisitedDate = DateTime.Now;
                _dbContext.VisitedBars.Update(visitedBar);
            }

            return _dbContext.SaveChanges() > 0;
        }

        public bool RemoveVisitedBar(int userId, int barId)
        {
            var visitedBar = _dbContext.VisitedBars.FirstOrDefault(vb => vb.UserId == userId && vb.BarId == barId);
            if (visitedBar != null)
            {
                _dbContext.VisitedBars.Remove(visitedBar);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public ICollection<VisitedBar> GetVisitedBarsByUserId(int userId)
        {
            return _dbContext.VisitedBars
                .Where(vb => vb.UserId == userId)
                .Include(vb => vb.Bar)
                .ToList();
        }
    }

}
