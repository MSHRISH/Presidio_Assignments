using EmployeeDALLibrary;
using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLLibrary
{
    public class EmployeeServices : IEmployeeServices
    {
        readonly IRepository<int, Employee> _employeeRepository;
        public EmployeeServices()
        {
            _employeeRepository = new EmployeeRepository();
        }
        public int AddEmployee(Employee employee)
        {
            var result = _employeeRepository.Add(employee);
            if (result != null)
            {
                return result.Id;
            }
            throw new EmployeeAlreadyExists();
        }

        public Employee DeleteEmployeeById(int id)
        {
            Employee employee = _employeeRepository.Delete(id);
            if (employee != null)
            { return employee; }
            throw new EmployeeDoesNotExit();
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = _employeeRepository.Get(id);
            if (employee != null)
            {
                return employee;
            }
            throw new EmployeeDoesNotExit();
        }

        public Department GetEmployeeDepartment(int id)
        {
            Employee employee = _employeeRepository.Get(id);
            if (employee != null)
            {
                return employee.EmployeeDepartment;
            }
            throw new EmployeeDoesNotExit();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var result = _employeeRepository.Add(employee);
            if (result != null)
            {
                return result;
            }
            throw new EmployeeAlreadyExists();
        }
    }
}
