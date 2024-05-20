using PizzaApi.Interfaces;
using PizzaApi.Models;
using PizzaApi.Repositories;
using PizzaApi.Execptions;

namespace PizzaApi.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<int, Pizza> _pizzaRepository;

        public UserServices(IRepository<int,Pizza> pizzaRepository) 
        { 
            _pizzaRepository = pizzaRepository;
        }
        public async Task<List<Pizza>> ShowMenu()
        {
            var AllItems = await _pizzaRepository.Get();
            List<Pizza> AvailItems= new List<Pizza>();
            foreach (var item in AllItems)
            {
                if (item.StockAvailable > 0)
                {
                    AvailItems.Add(item);
                }
            }
            if( AvailItems.Count == 0) 
            {
                throw new NoStockAvailable();
            }
            return AvailItems;
        }
    }
}
