using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LastBeer.Back.Models
{
    public class Bar
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PlaceId { get; set; }
        public string Name { get; set; }
    }
}
