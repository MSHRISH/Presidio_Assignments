using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLLibrary
{
    public interface IDepartmentServices
    {
        int AddDepartment(Department department);
        Department GetDepartmentById(int id);
        Department UpdateDepartment(Department department);
        Department DeleteDepartment(int id);
        List<Department> GetAllDepartment();

    }
}
