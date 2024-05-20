using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IEmployeeService
    {
        public Task<Employee> GetEmployeeByPhone(string PhoneNumber);
        public Task<Employee> UpdateEmployeePhone(int id,string PhoneNumber);
        public Task<IEnumerable<Employee>> GetEmployees();
    }
}
