using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LastBeer.Back.Models.Dtos.VisitedBarDtos
{
    public class VisitedBarDto
    {
        public int Id { get; set; }
        public int BarId { get; set; }
        public Bar Bar { get; set; }
        public int UserId { get; set; }
        public DateTime VisitedDate { get; set; }
    }
}
