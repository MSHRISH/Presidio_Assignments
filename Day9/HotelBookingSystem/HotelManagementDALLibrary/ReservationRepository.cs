using ModelLibrary;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDALLibrary
{
    public class ReservationRepository : IReservationRepository<int, Reservation>
    {
        readonly Dictionary<int, Reservation> _reservation;

        //Availability
        public int SingleBookings = 0;
        public int DoubleBookings= 0;
        public int SuiteBookings = 0;

        public int GetSingleBookings()
        {
            return SingleBookings;
        }
        public int GetDoubleBookings()
        {
            return DoubleBookings;
        }
        public int GetSuiteBookings()
        {
            return SuiteBookings;
        }

        public ReservationRepository()
        {
            _reservation = new Dictionary<int, Reservation>();
        }   
        
       

        public Reservation MakeReservation(Reservation reservation, string RoomType)
        {
            _reservation.Add(reservation.ReservationId, reservation);
            if (RoomType == "Single")
            {
                SingleBookings++;
            }
            else if(RoomType == "Double")
            {
                DoubleBookings++;
            }
            else
            {
                SuiteBookings++;
            }
            return reservation;    
        }

    
        public List<Reservation> GetAllReservations()
        {
            return _reservation.Values.ToList();
        }

        public Reservation GetReservationById(int reservationId)
        {
            return _reservation[reservationId];
        }


    }
}
