namespace LastBeer.Back.Models.Dtos.UserDtos
{
    public class UserLoginResponseDto
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
