using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDALLibrary
{
    public interface IReservationRepository<k, T> where T : class
    {
        T MakeReservation(T reservation, string RoomType);

        int GetSingleBookings();
        int GetDoubleBookings();
        int GetSuiteBookings();

        List<T> GetAllReservations();
        T GetReservationById(int reservationId);
    }
}
