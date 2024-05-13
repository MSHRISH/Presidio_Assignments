using Models;
using RequestTrackerDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmployeeLoginBL:IEmployeeLoginBL
    {
        private IRepository<int, Employee> _repository;
        public EmployeeLoginBL()
        {
            _repository = new EmployeeRepository(new RequestTrackerContext());
        }

        public async Task<bool> Login(Employee employee)
        {
            Employee emp = await _repository.GetByKey(employee.Id);

            if (emp != null)
            {
                if (emp.Password == employee.Password)
                {
                    return true;
                }

            }

            return false;
        }
        public async Task<Employee> Register(Employee employee)
        {
            var result = await _repository.Add(employee);
            return result;
        }
        public async Task<Employee> GetEmployee(Employee employee)
        {
            Employee emp = await _repository.GetByKey(employee.Id);
            return emp;

        }
    }
}
