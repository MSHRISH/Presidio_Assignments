using Microsoft.EntityFrameworkCore;
using PizzaApi.Contexts;
using PizzaApi.Execptions;
using PizzaApi.Interfaces;
using PizzaApi.Models;

namespace PizzaApi.Repositories
{
    public class UserAuthRepository : IRepository<int, Authentication>
    {
        private readonly PizzaAPIContext _context;

        public UserAuthRepository(PizzaAPIContext context) 
        {
            _context=context;
        }
        public async Task<Authentication> Add(Authentication item)
        {
            item.Status = "Disabled";
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Authentication> Delete(int key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new UserDoesNotExist();
        }

        public async Task<Authentication> Get(int key)
        {
            return (await _context.Authentications.SingleOrDefaultAsync(u => u.UserId == key)) ?? throw new UserDoesNotExist();
        }

        public async Task<IEnumerable<Authentication>> Get()
        {
            return (await _context.Authentications.ToListAsync());
        }

        public async Task<Authentication> Update(Authentication item)
        {
            var user = await Get(item.UserId);
            if (user != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new UserDoesNotExist();
        }
    }
}
