using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App
{
    internal class question3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Number: ");
            int user_input=Convert.ToInt32(Console.ReadLine());
            int total = 0;
            int n = 0;

            while(user_input >= 0)
            {
                if (user_input % 7 == 0)
                {
                    total += user_input;
                    n++;
                }
                Console.WriteLine("Enter a Number: ");
                user_input = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Negative number entered application stopped!");
            Console.Write("Average is : ");
            Console.WriteLine(total / n);
        }
    }
}
