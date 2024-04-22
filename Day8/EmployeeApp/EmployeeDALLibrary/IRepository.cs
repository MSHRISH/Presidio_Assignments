using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDALLibrary
{
    public interface IRepository<K, T> where T : class
    {
        T Get(K key);
        T Delete(K key);
        T Add(T item);
        List<T> GetAll();
        T Update(T item);
        int GenerateId();
    }
}
