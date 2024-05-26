using System.ComponentModel.DataAnnotations;

namespace LastBeer.Back.Models.Dtos.BarDtos
{
    public class BarInsertDto
    {
        public string PlaceId { get; set; }
        public string Name { get; set; }
    }
}
