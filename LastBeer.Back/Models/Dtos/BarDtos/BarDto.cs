using System.ComponentModel.DataAnnotations;

namespace LastBeer.Back.Models.Dtos.BarDtos
{
    public class BarDto
    {
        public int Id { get; set; }
        public string PlaceId { get; set; }
        public string Name { get; set; }
    }
}
