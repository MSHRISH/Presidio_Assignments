using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public interface IRepository<K, T> where T : class
    {
        Task<T> Add(T entity);

        Task<T> GetByKey(K key);

        Task<List<T>> GetAll();

        Task<T> Update(T entity);

        Task<T> DeleteByKey(K key);
    }
}
