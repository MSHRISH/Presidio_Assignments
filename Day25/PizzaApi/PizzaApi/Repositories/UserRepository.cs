using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using PizzaApi.Contexts;
using PizzaApi.Execptions;
using PizzaApi.Interfaces;
using PizzaApi.Models;

namespace PizzaApi.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly PizzaAPIContext _context;

        public UserRepository(PizzaAPIContext context) 
        {
            _context=context;
        }
        public async Task<User> Add(User item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null)
            {
                _context.Remove(employee);
                _context.SaveChangesAsync(true);
                return employee;
            }
            throw new UserDoesNotExist();
        }

        public async Task<User> Get(int key)
        {
            var employee = await _context.Users.FirstOrDefaultAsync(e => e.Id == key);
            return employee;
        }

        public async Task<IEnumerable<User>> Get()
        {
            var  users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> Update(User item)
        {
            var employee = await Get(item.Id);
            if (employee != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync(true);
                return employee;
            }
            throw new UserDoesNotExist();
        }
    }
}
