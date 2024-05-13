using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class EmployeeRepository: IRepository<int, Employee>
    {
        private readonly RequestTrackerContext _context;

        public EmployeeRepository(RequestTrackerContext context)
        {
            _context = context;

        }
        public async Task<Employee> GetByKey(int key)
        {
            Employee emp = await _context.Employees.FirstOrDefaultAsync(e => e.Id == key);
            return emp;

        }
        public async Task<List<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<Employee> Add(Employee entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
        public async Task<Employee> DeleteByKey(int key)
        {
            Employee emp = await GetByKey(key);
            if (emp != null)
            {
                _context.Remove(emp);
                await _context.SaveChangesAsync();

            }
            return emp;
        }
        public async Task<Employee> Update(Employee entity)
        {            
            Employee emp = await GetByKey(entity.Id);
            if (emp != null)
            {
                _context.Update(entity);
                _context.SaveChanges();
                return entity;
            }

            return null;

        }
    }
}
