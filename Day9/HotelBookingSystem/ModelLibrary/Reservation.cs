using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Reservation
    {
        public int ReservationId { get; set; }  
        public DateTime Checkin { get; set; }
        
        private DateTime _checkOut;
        public DateTime Checkout { get; set; }
        public int RoomId { get; set; }
        public string RoomType { get; set; }=string.Empty;
        public bool AC {  get; set; }
        public bool Wifi {  get; set; }
        public string Status { get; set; } = string.Empty;
        public string GuestName {  get; set; }=string.Empty;

        public double Price {  get; set; }
    
        public Reservation(int reservationid,DateTime checkin,DateTime checkout,String roomtype,bool ac,bool wifi)
        {
            ReservationId = reservationid;
            Checkin = checkin;
            Checkout = checkout;
            RoomType= roomtype;
            AC = ac;
            Wifi = wifi;
        }
    }
}
