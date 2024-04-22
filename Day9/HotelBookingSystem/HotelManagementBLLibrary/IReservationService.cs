using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementBLLibrary
{
    public interface IReservationService
    {
        bool ClashDate(DateTime ACheckin, DateTime ACheckout, DateTime BCheckin, DateTime BCheckout);
        bool CheckAvailability(Reservation reservation);
        double CalculatePrice(string RoomType, DateTime CheckIn, DateTime CheckOut);
        Reservation MakeReservation(Reservation reservation);
        List<Reservation> ShowAllReservations();
    }
}
