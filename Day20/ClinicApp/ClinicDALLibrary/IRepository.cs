using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary;

namespace ClinicDALLibrary
{
    public interface IRepository<K,T> where T : class
    {
        List<T> GetAllAppointments();
        T GetAppointment(K key);
        T AddAppointment(T appointment);
        T UpdateAppointment(T appointment);
        T DeleteAppointment(K key);
    }
}
