using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeLoginBL
    {
        public Task<bool> UserLogin(int EmployeeId, string Password);
        public Task<bool> AdminLogin(int EmployeeId, string Password);
        public Task<int> RegisterEmployee(string EmployeeName, string password, int Role);
    }
}
