using HotelManagementDALLibrary;
using ModelLibrary;

namespace HotelManagementBLLibrary
{
    public class ReservationService
    {
        readonly IRoomsRepository<int, Room> _room;
        readonly IReservationRepository<int, Reservation> _reservation;

        public ReservationService()
        {
            _room = new RoomsRepository();
            _reservation = new ReservationRepository();
        }
        public bool ClashDate(DateTime ACheckin,DateTime ACheckout, DateTime BCheckin, DateTime BCheckout)
        {
            if (ACheckout < BCheckin)
            {
                return false;
            }
            if(ACheckin>BCheckout)
            {
                return false;
            }
            return true;
        }
        public bool CheckAvailability(Reservation reservation)
        {
            Room room = _room.GetRoomById(reservation.RoomId);
            int Bookings;
            if (room.RoomType == "Single")
            {
                Bookings = _reservation.GetSingleBookings();
            }
            else if(room.RoomType == "Double")
            {
                Bookings= _reservation.GetDoubleBookings();
            }
            else
            {
                Bookings=_reservation.GetSuiteBookings();
            }
            if (Bookings<10)
            {
                return true;
            }
            foreach(var i in _reservation.GetAllReservations())
            {

            }
            return false;
            
        }

        

    }
}
