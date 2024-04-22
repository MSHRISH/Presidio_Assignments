using ModelLibrary;

namespace HotelBookingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reservation reservation =new Reservation(101,DateTime.Now,DateTime.Now,101,true,true);
            reservation.Status = "undergoing";
            reservation.GuestName = "shrish";
            Console.WriteLine(reservation.GuestName);
        }
    }
}
