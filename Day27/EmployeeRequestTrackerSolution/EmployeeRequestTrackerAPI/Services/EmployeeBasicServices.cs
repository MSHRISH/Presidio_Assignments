using EmployeeRequestTrackerAPI.Execptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Repositories;

namespace EmployeeRequestTrackerAPI.Services
{
    public class EmployeeBasicServices : IEmployeeService
    {
        private readonly IRepository<int, Employee> _repository;

        public EmployeeBasicServices(IRepository<int,Employee> repository) 
        {
            _repository=repository;
        }
        public async Task<Employee> GetEmployeeByPhone(string PhoneNumber)
        {
            var employee=(await _repository.GetAll()).FirstOrDefault(e=>e.phone==PhoneNumber);
            if (employee == null)
            {
                throw new NoSuchEmployeeExecption();
            }
            return employee;    
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees=await _repository.GetAll();
            if (employees.Count() == 0)
            {
                throw new NoSuchEmployeeExecption();
            }
            return employees;
        }

        public async Task<Employee> UpdateEmployeePhone(int id,string PhoneNumber)
        {
            var employee=await _repository.Get(id);
            if (employee == null) 
            {
                throw new NoSuchEmployeeExecption();
            }
            employee.phone= PhoneNumber;
            employee=await _repository.Update(employee);
            return employee;    

        }
    }
}
