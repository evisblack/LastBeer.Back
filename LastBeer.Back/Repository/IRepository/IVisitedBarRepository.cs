using LastBeer.Back.Models;
using XAct.Users;

namespace LastBeer.Back.Repository.IRepository
{
    public interface IVisitedBarRepository
    {
        bool AddOrUpdateVisitedBar(int userId, Bar bar);
        bool RemoveVisitedBar(int userId, int barId);
        ICollection<VisitedBar> GetVisitedBarsByUserId(int userId);  
    }
}
