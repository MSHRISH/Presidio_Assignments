using ClinicAPI.Contexts;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Repositories
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly ClinicContext _context;

        public DoctorRepository(ClinicContext context) 
        { 
            _context=context;
        }
        public async Task<Doctor> Add(Doctor item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Doctor> Delete(int key)
        {
            var doctor= await Get(key);
            if (doctor!= null)
            {
                _context.Remove(doctor);
                _context.SaveChangesAsync();
            }
            throw new DoctorDoesntExist();
        }

        public Task<Doctor> Get(int key)
        {
            var employee = _context.Doctors.FirstOrDefaultAsync(e=>e.Id==key);
            return employee;
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;
        }

        public async Task<Doctor> Update(Doctor item)
        {
            var doctor= await Get(item.Id);
            if (doctor!= null)
            {
                _context.Update(item);
                _context.SaveChangesAsync();
                return doctor;
            }
            throw new DoctorDoesntExist();
        }
    }
}
