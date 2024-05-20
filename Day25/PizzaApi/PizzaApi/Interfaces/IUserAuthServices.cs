using PizzaApi.Models;
using PizzaApi.Models.DTO;

namespace PizzaApi.Interfaces
{
    public interface IUserAuthServices
    {
        public Task<User> Login(LoginUserDTO loginDTO);
        public Task<User> Register(RegisterUserDTO registerDTO);
    }
}
