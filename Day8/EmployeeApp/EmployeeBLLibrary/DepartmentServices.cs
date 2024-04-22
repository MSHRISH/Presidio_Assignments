using EmployeeDALLibrary;
using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLLibrary
{
    public class DepartmentServices : IDepartmentServices
    {
        readonly IRepository<int, Department> _departmentRepository;

        public DepartmentServices()
        {
            _departmentRepository=new DepartmentRepository();
        }
        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            throw new DepartmentAlreadyExists();
        }

        public Department DeleteDepartment(int id)
        {
            Department department = _departmentRepository.Delete(id);
            if (department!= null)
            { return department; }
            throw new DepartmentDoesNotExist();
        }

        public List<Department> GetAllDepartment()
        {
            return _departmentRepository.GetAll();
        }

        public Department GetDepartmentById(int id)
        {
            Department department = _departmentRepository.Get(id);
            if (department != null)
            {
                return department;
            }
            throw new DepartmentDoesNotExist();
        }

        public Department UpdateDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result;
            }
            throw new DepartmentAlreadyExists();
        }
    }
}
