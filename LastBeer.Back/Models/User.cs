using System.ComponentModel.DataAnnotations;

namespace LastBeer.Back.Models
{
    public class User
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }

        public List<FavouriteBar> Favorites { get; set; } = new List<FavouriteBar>();
        public List<VisitedBar> VisitedBars { get; set; } = new List<VisitedBar>();
        public List<Score> Scores { get; set; } = new List<Score>();
    }
}
