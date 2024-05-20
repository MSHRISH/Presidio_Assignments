using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IEmployeeAuthenticationServices
    {
        public Task<LoginReturnDTO> Login(EmployeeLoginDTO loginDTO);
        public Task<Employee> Register(RegisterDTO registerDTO);
    }
}
