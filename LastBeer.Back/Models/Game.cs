using System.ComponentModel.DataAnnotations;

namespace LastBeer.Back.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
