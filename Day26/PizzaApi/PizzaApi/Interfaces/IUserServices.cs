using PizzaApi.Models;

namespace PizzaApi.Interfaces
{
    public interface IUserServices
    {
        public Task<List<Pizza>> ShowMenu();
    }
}
