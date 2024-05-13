using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestRepository: IRepository<int, Request>
    {
        private readonly RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> GetByKey(int key)
        {
            Request request = await _context.Requests.FirstOrDefaultAsync(e => e.RequestId == key);
            return request;

        }
        public async Task<List<Request>> GetAll()
        {
            return await _context.Requests.ToListAsync();
        }
        public async Task<Request> DeleteByKey(int key)
        {
            Request emp = await GetByKey(key);
            if (emp != null)
            {
                _context.Remove(emp);
                await _context.SaveChangesAsync();

            }
            return emp;
        }
        public async Task<Request> Add(Request entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;

        }       
        public async Task<Request> Update(Request entity)
        {            
            Request emp = await GetByKey(entity.RequestId);
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
