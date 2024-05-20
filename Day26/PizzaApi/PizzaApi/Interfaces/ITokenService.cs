using PizzaApi.Models;

namespace PizzaApi.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
