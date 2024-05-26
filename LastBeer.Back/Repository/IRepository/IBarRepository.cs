using LastBeer.Back.Models;

namespace LastBeer.Back.Repository.IRepository
{
    public interface IBarRepository
    {
        Bar GetById(int id);
        ICollection<Bar> GetBars();
        bool AddBar(Bar bar);
        bool UpdateBar(Bar bar);
        bool DeleteBar(int barId);
        Bar GetByPlaceId(string placeId);
    }

}
