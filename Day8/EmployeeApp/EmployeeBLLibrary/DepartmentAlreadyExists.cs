using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLLibrary
{
    public class DepartmentAlreadyExists:Exception
    {
        string message;
        public DepartmentAlreadyExists()
        {
            message = "The department already exists";
        }
        public override string Message => Message;
    }
}
