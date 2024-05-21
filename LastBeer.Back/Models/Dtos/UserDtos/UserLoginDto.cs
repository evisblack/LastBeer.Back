using System.ComponentModel.DataAnnotations;

namespace LastBeer.Back.Models.Dtos.UserDtos
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; }


    }
}
