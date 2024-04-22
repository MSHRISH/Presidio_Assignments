using ModelLibrary;

namespace HotelBookingSystem
{
    internal class Program
    {
        public void SearchForAvailableRoom()
        {
            Random random = new Random();
            int ReservationId= random.Next();

            Console.WriteLine("Enter Checkin Date: ");
            DateTime Checkin=Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Checkout Date: ");
            DateTime Checkout=Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Room Type: ");
            string Roomtype = Console.ReadLine();
            Console.WriteLine("No.of Members: ");
            int Members=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Air-Condition: ");
            bool AC=Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Wifi");
            bool Wifi=Convert.ToBoolean(Console.ReadLine());

            Reservation reservation = new Reservation(ReservationId, Checkin, Checkout, Roomtype, AC, Wifi);

            //Checking Availability




        }
        public void GuestService()
        {
            
            while (true)
            {
                Console.WriteLine("1. Search for Available Room");
                switch (Console.ReadLine())
                {
                    case "1":
                        SearchForAvailableRoom();
                        break;
                    default:
                        return;
                }
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.GuestService();
            
            
        }
    }
}
