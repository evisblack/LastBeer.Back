using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LastBeer.Back.Models
{
    public class VisitedBar
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("BarId")]
        public int BarId { get; set; }
        public Bar Bar { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public DateTime VisitedDate { get; set; }
    }
}
