using System.ComponentModel.DataAnnotations;

namespace LastBeer.Back.Models.Dtos.BarDtos
{
    public class BarVisitedInsertDto
    {
        public int Id { get; set; }
        public string PlaceId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
