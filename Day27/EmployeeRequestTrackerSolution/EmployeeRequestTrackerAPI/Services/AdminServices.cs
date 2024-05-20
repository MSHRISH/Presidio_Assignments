using EmployeeRequestTrackerAPI.Execptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IRepository<int, Employee> _employeeRepository;
        private readonly IRepository<int, Authentication> _authenticationRepository;

        public AdminServices(IRepository<int,Employee> employeeRepository,IRepository<int,Authentication> authenticationRepository) 
        { 
            _employeeRepository=employeeRepository;
            _authenticationRepository=authenticationRepository;
        }
        public async Task<bool> ActivateUser(int id)
        {
            Authentication employee = await _authenticationRepository.Get(id);
            if (employee == null)
            {
                throw new NoSuchEmployeeExecption();
            }
            employee.Status = "Enabled";
            employee=await _authenticationRepository.Update(employee);
            return true;
            
        }
    }
}
