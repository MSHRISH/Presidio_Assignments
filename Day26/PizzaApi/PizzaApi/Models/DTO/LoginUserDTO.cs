namespace PizzaApi.Models.DTO
{
    public class LoginUserDTO
    {
        public int UserId { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
