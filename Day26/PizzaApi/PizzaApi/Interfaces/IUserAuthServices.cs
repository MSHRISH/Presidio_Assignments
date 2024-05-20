using PizzaApi.Models;
using PizzaApi.Models.DTO;

namespace PizzaApi.Interfaces
{
    public interface IUserAuthServices
    {
        public Task<LoginReturnDTO> Login(LoginUserDTO loginDTO);
        public Task<User> Register(RegisterUserDTO registerDTO);
    }
}
