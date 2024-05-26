using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LastBeer.Back.Models
{
    public class Bar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PlaceId { get; set; }
        [Column(TypeName = "text")]
        public string Name { get; set; }
    }
}
