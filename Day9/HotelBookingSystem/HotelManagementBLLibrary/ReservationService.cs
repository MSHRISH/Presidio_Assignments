using HotelManagementDALLibrary;
using ModelLibrary;

namespace HotelManagementBLLibrary
{
    public class ReservationService: IReservationService
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
            Room BookingRoom = _room.GetRoomById(reservation.RoomId);
            int Bookings;
            if (BookingRoom.RoomType == "Single")
            {
                Bookings = _reservation.GetSingleBookings();
            }
            else if(BookingRoom.RoomType == "Double")
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
                Room RoomDetails=_room.GetRoomById(i.RoomId);
                if (RoomDetails.RoomType == BookingRoom.RoomType)
                {
                    if (!ClashDate(i.Checkin, i.Checkout, reservation.Checkin, reservation.Checkout))
                    {
                        return true;
                    }
                }
            }
            return false;
            
        }

        public double CalculatePrice(string RoomType,DateTime CheckIn,DateTime CheckOut)
        {
            int days=(int)(CheckIn-CheckOut).Days;
            if(RoomType == "Single")
            {
                return 1000 * days;
            }
            else if(RoomType == "Double")
            {
                return 2000*days;
            }
            else
            {
                return 5000 * days;
            }
        }

        public Reservation MakeReservation(Reservation reservation)
        {
            if (CheckAvailability(reservation))
            {
                Room room=_room.GetRoomById(reservation.RoomId);
                reservation.Price=CalculatePrice(room.RoomType,reservation.Checkin,reservation.Checkout);
                return _reservation.MakeReservation(reservation, room.RoomType);
            }
            else
            {
                throw new NoAvailabilityExecption();
            }
        }

        public List<Reservation> ShowAllReservations()
        {
            return _reservation.GetAllReservations();
        }

        public Reservation ShowReservation(int ReservationId)
        {
            return _reservation.GetReservationById(ReservationId);
        }    
    }
}
