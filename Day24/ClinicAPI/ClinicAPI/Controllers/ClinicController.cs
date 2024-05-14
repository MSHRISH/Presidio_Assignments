using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using ClinicAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public ClinicController(IDoctorService doctorService) 
        { 
            _doctorService=doctorService;
        }
        [Route("GetAllDoctors")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetAllDoctors()
        {
            try
            {
                var doctors = await _doctorService.GetDoctors();
                return Ok(doctors);
            }
            catch (DoctorDoesntExist exec) 
            {
                return NotFound(exec.Message);
            }
        }
        [Route("GetDoctorsBySpeciality")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctorBySpeciality(string Speciality)
        {
            try
            {
                var doctors = await _doctorService.GetDoctorsBySpeciality(Speciality);
                return Ok(doctors);
            }
            catch(DoctorDoesntExist exec)
            {
                return NotFound(exec.Message);
            }
        }
        [Route("UpdateDoctorExperience")]
        [HttpPost]
        public async Task<ActionResult<Doctor>> UpdateDoctorExperience(int Id,int Experience)
        {
            try
            {
                var doctor = await _doctorService.UpdateDoctorExperience(Id,Experience);
                return Ok(doctor);
            }
            catch (DoctorDoesntExist exec)
            {
                return NotFound(exec.Message);
            }
        }
    }
}
