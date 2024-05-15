using System.ComponentModel.DataAnnotations;

namespace LastBeer.Back.Models
{
    public class UserInsertDto
    {
        public string UserName { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }

    }
}
