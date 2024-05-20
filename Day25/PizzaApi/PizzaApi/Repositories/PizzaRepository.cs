using Microsoft.EntityFrameworkCore;
using PizzaApi.Contexts;
using PizzaApi.Execptions;
using PizzaApi.Interfaces;
using PizzaApi.Models;

namespace PizzaApi.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private readonly PizzaAPIContext _context;

        public PizzaRepository(PizzaAPIContext context) 
        {
            _context=context;
        }
        public async Task<Pizza> Add(Pizza item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Pizza> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null)
            {
                _context.Remove(employee);
                _context.SaveChangesAsync(true);
                return employee;
            }
            throw new PizzaDoesNotExist();
        }

        public async Task<Pizza> Get(int key)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(e => e.Id == key);
            return pizza;
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            var pizzas= await _context.Pizzas.ToListAsync();
            return pizzas;
        }

        public  async Task<Pizza> Update(Pizza item)
        {
            var employee = await Get(item.Id);
            if (employee != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync(true);
                return employee;
            }
            throw new PizzaDoesNotExist();
        }
    }
}
