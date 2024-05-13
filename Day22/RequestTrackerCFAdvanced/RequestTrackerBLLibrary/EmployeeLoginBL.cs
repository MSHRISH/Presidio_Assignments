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
        public readonly IRepository<int, Employee> _repository;
        public EmployeeLoginBL()
        {
            _repository = new EmployeeRepository(new RequestTrackerContext());
        }

        
        public async Task<bool> UserLogin(int EmployeeId,string Password)
        {
            Employee emp=await _repository.GetByKey(EmployeeId);
            if (emp != null)
            {
                if (emp.Password == Password && emp.Role=="User")
                {
                    return true;
                }

            }
            return false;
        }
        public async Task<bool> AdminLogin(int EmployeeId,string Password)
        {
            Employee emp = await _repository.GetByKey(EmployeeId);
            if (emp != null)
            {
                if (emp.Password == Password && emp.Role == "Admin")
                {
                    return true;
                }

            }
            return false;
        }
       
        public async Task<int> GenerateEmployeeId()
        {
            var employees = await _repository.GetAll();
            int id = employees.Max(x => x.Id);
            return ++id;
        }
        public async Task<int> RegisterEmployee(string EmployeeName,string password,int Role)
        {
            Employee employee=new Employee();
            employee.Name = EmployeeName;
            employee.Password = password;
            if(Role == 1)
            {
                employee.Role = "User";
            }
            else
            {
                employee.Role = "Admin";
            }
            employee.Id=await GenerateEmployeeId();
            var AddedEmployee=await _repository.Add(employee);  
            return employee.Id;

        }
        public async Task<Employee> GetEmployee(int EmployeeId)
        {
            Employee emp = await _repository.GetByKey(EmployeeId);
            return emp;

        }
    }
}
