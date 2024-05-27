using LastBeer.Back.Models;

namespace LastBeer.Back.Repository.IRepository
{
    public interface IBarRepository
    {
        //Obtiene un bar usando como parámetro el Id del Bar
        Bar GetById(int id);
        //Obtiene la lista de los bares
        ICollection<Bar> GetBars();
        //Añade un nuevo Bar, si no existe
        bool AddBar(Bar bar);
        //Actualiza un Bar que ya existe en la base de datos
        bool UpdateBar(Bar bar);
        //Elimina un Bar existente
        bool DeleteBar(int barId);
        //Obtiene el Bar usando como parametro él placeID
        Bar GetByPlaceId(string placeId);
    }

}
