using ModelLibrary;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDALLibrary
{
    public class ReservationRepository : IReservation<int, Reservation>
    {
        readonly Dictionary<int, Reservation> _reservation;

        //Availability
        public int SingleRoom = 10;
        public int DoubleRoom = 10;
        public int suiteRoom = 5;

        public ReservationRepository()
        {
            _reservation = new Dictionary<int, Reservation>();
        }   
        int GenerateId()
        {
            if (_reservation.Count == 0)
                return 1;
            int id = _reservation.Keys.Max();
            return ++id;
        }

        public Reservation MakeReservation(Reservation reservation)
        {
            _reservation.Add(GenerateId(), reservation);
            return reservation;    
        }

        public bool CheckReservation(Room room)
        {
            return true;
        }
    }
}
