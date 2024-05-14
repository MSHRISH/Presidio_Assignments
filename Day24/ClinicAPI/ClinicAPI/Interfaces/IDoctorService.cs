using ClinicAPI.Models;

namespace ClinicAPI.Interfaces
{
    public interface IDoctorService
    {
        public Task<IEnumerable<Doctor>> GetDoctors();
        public Task<IEnumerable<Doctor>> GetDoctorsBySpeciality(string Speciality);
        public Task<Doctor> UpdateDoctorExperience(int id, int experience);
    }
}
