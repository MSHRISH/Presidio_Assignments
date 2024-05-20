using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Execptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Repositories
{
    public class RequestRepository:IRepository<int,Request>
    {
        private readonly RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext context) 
        { 
            _context=context;
        }

        public async Task<Request> Add(Request item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Request> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null)
            {
                _context.Remove(employee);
                _context.SaveChangesAsync();
            }
            throw new RequestNotFound();
        }

        public async Task<Request> Get(int key)
        {
            var employee = await _context.Requests.FirstOrDefaultAsync(e => e.RequestId== key);
            return employee;
        }

        public async Task<IEnumerable<Request>> GetAll()
        {
            var employees = await _context.Requests.ToListAsync();
            return employees;
        }

        public async Task<Request> Update(Request item)
        {
            var employee = await Get(item.RequestId);
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
