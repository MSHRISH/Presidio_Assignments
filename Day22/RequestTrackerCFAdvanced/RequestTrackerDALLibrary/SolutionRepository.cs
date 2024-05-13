using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class SolutionRepository : IRepository<int, Solution>
    {
        private readonly RequestTrackerContext _context;

        public SolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Solution> GetByKey(int key)
        {
            Solution solution= await _context.Solutions.FirstOrDefaultAsync(e => e.SolutionId == key); ;
            return solution;
        }
        public async Task<List<Solution>> GetAll()
        {
            return await _context.Solutions.ToListAsync();
        }
        public async Task<Solution> Add(Solution entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Solution> DeleteByKey(int key)
        {
            Solution emp = await GetByKey(key);
            if (emp != null)
            {
                _context.Remove(emp);
                await _context.SaveChangesAsync();

            }
            return emp;
        }
        public async Task<Solution> Update(Solution entity)
        {           
            Solution emp = await GetByKey(entity.SolutionId);
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
