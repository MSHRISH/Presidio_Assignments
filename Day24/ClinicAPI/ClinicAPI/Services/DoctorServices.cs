using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using ClinicAPI.Repositories;

namespace ClinicAPI.Services
{
    public class DoctorServices : IDoctorService
    {
        private readonly IRepository<int, Doctor> _repository;

        public DoctorServices(IRepository<int,Doctor> repository) 
        {
            _repository=repository;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors=await _repository.GetAll();
            if (doctors.Count() == 0)
            {
                throw new DoctorDoesntExist();
            }
            return doctors;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpeciality(string Speciality)
        {
            var doctors = await _repository.GetAll();
            if (doctors.Count() == 0)
            {
                throw new DoctorDoesntExist();
            }
            var doctorsBySpeciality = doctors.Where(d => d.Speciality == Speciality);
            if (!doctorsBySpeciality.Any())
            {
                throw new DoctorDoesntExist();
            }
            return doctorsBySpeciality;
        }

        public async Task<Doctor> UpdateDoctorExperience(int id, int experience)
        {
            var doctor=await _repository.Get(id);
            if (doctor == null)
            {
                throw new DoctorDoesntExist();
            }
            doctor.Experience = experience;
            doctor=await _repository.Update(doctor);
            return doctor;
        }
    }
}
