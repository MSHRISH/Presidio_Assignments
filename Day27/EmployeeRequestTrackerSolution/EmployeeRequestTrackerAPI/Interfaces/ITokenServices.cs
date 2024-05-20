using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface ITokenServices
    {
        public string GenerateToken(Employee employee);
    }
}
