using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Execptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Repositories
{
    public class AuthenticationRepository : IRepository<int, Authentication>
    {
        private readonly RequestTrackerContext _context;

        public AuthenticationRepository(RequestTrackerContext context) 
        { 
            _context=context;
        }
        public async Task<Authentication> Add(Authentication item)
        {
            
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Authentication> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null)
            {
                _context.Remove(employee);
                _context.SaveChangesAsync();
            }
            throw new NoSuchEmployeeExecption();
        }

        public async Task<Authentication> Get(int key)
        {
            var employee = await _context.Authentications.FirstOrDefaultAsync(e => e.EmployeeId == key);
            return employee;
        }

        public async Task<IEnumerable<Authentication>> GetAll()
        {
            var employees = await _context.Authentications.ToListAsync();
            return employees;
        }

        public async Task<Authentication> Update(Authentication item)
        {
            var employee = await Get(item.EmployeeId);
            if (employee != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync();
                return employee;
            }
            throw new NoSuchEmployeeExecption();
        }
    }
}
