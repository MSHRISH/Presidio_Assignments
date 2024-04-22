using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLLibrary
{
    public class EmployeeAlreadyExists:Exception
    {
        string message;
        public EmployeeAlreadyExists()
        {
            message = "The employee already exists";
        }
        public override string Message => Message;
    }
}
