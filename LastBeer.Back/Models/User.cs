using System.ComponentModel.DataAnnotations;

namespace LastBeer.Back.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public string Role { get; set; }

        public List<FavouriteBar> Favorites { get; set; } = new List<FavouriteBar>();
        public List<VisitedBar> VisitedBars { get; set; } = new List<VisitedBar>();
        public List<Score> Scores { get; set; } = new List<Score>();
    }

}
