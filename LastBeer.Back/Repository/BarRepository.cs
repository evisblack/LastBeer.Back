using LastBeer.Back.Data;
using LastBeer.Back.Models;
using LastBeer.Back.Repository.IRepository;

namespace LastBeer.Back.Repository
{
    public class BarRepository : IBarRepository
    {
        private readonly AppDbContext _dbContext;

        public BarRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Bar GetById(int id)
        {
            return _dbContext.Bars.FirstOrDefault(b => b.Id == id);
        }

        public Bar GetByPlaceId(string placeId)
        {
            return _dbContext.Bars.FirstOrDefault(b => b.PlaceId == placeId);
        }

        public ICollection<Bar> GetBars()
        {
            return _dbContext.Bars.OrderBy(b => b.Name).ToList();
        }

        public bool AddBar(Bar bar)
        {
            _dbContext.Bars.Add(bar);
            return Save();
        }

        public bool UpdateBar(Bar bar)
        {
            _dbContext.Bars.Update(bar);
            return Save();
        }

        public bool DeleteBar(int barId)
        {
            var bar = _dbContext.Bars.FirstOrDefault(b => b.Id == barId);
            if (bar != null)
            {
                _dbContext.Bars.Remove(bar);
                return Save();
            }
            return false;
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }
    }

}
