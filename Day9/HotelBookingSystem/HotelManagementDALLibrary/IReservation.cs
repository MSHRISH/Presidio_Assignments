using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDALLibrary
{
    public interface IReservation<k, T> where T : class
    {
        T MakeReservation(T reservation);


    }
}
