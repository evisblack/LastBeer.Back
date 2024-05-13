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
    }
}
