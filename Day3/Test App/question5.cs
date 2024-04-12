using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App
{
    internal class question5
    {
        static void Main(string[] args)
        {
            int attempt = 3;

            while (attempt > 0) {
                Console.Write("Enter Username : ");
                string user_name = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Enter Password : ");
                string password = Console.ReadLine();
                if ((password == "123") && (user_name == "ABC")) {
                    Console.WriteLine("You are logged in");
                    break;
                }
                attempt--;
                Console.WriteLine("Wrong Credentials \n");
                if (attempt == 0)
                {
                    Console.WriteLine("Number of attempts exceeded");
                }
                
            }

            
        }

    }
}
