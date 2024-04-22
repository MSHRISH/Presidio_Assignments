using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLLibrary
{
    public class EmployeeDoesNotExit:Exception
    {
        string message;
        public EmployeeDoesNotExit()
        {
            message = "The employee doesn't exist";
        }
        public override string Message => Message;
    }
}
