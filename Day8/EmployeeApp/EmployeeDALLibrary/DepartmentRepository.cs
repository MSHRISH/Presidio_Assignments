﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;

namespace EmployeeDALLibrary
{
    public class DepartmentRepository : IRepository<int, Department>
    {
        private readonly Dictionary<int, Department> _departments;
        public DepartmentRepository()
        {
            _departments = new Dictionary<int, Department>();
        }
        public int GenerateId()
        {
            return _departments.Count == 0 ? 1 : _departments.Keys.Max() + 1;
        }

        public Department Add(Department item)
        {
            if (_departments.ContainsValue(item))
            {
                return null;
            }

            int id = GenerateId();
            item.Id = id;
            _departments.Add(id, item);
            return item;
        }

        public Department Delete(int key)
        {
            if (_departments.ContainsKey(key))
            {
                var department = _departments[key];
                _departments.Remove(key);
                return department;
            }

            return null!;
        }

        public Department? Get(int key)
        {
            return _departments.ContainsKey(key) ? _departments[key] : null;
        }

        public List<Department> GetAll()
        {
            return _departments.Values.ToList();
        }

        public Department Update(Department item)
        {
            if (_departments.ContainsKey(item.Id))
            {
                _departments[item.Id] = item;
                return item;
            }

            return null!;
        }
    }
}
