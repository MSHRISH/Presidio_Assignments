using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;

namespace EmployeeBLLibrary
{
    public interface IEmployeeServices
    {
        int AddEmployee(Employee employee);
        Employee GetEmployeeById(int id);
        Employee UpdateEmployee(Employee employee);
        Employee DeleteEmployeeById(int id);
        List<Employee> GetAllEmployees()
        Department GetEmployeeDepartment(int id);

    }
}
