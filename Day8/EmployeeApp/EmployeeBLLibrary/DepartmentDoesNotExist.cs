using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLLibrary
{
    public class DepartmentDoesNotExist:Exception
    {
        string message;
        public DepartmentDoesNotExist()
        {
            message = "The department doesn't exist";
        }
        public override string Message => Message;
    }
}
