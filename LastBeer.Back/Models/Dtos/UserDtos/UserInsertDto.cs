using System.ComponentModel.DataAnnotations;

namespace LastBeer.Back.Models.Dtos.UserDtos
{
    public class UserInsertDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }

    }
}
