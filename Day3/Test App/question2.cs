using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App
{
    internal class question2
    {
        static void Main(string[] args)
        {
            int max_num=0;
            int user_input;
            Console.WriteLine("Enter a Number: ");
            user_input=Convert.ToInt32(Console.ReadLine());
            while (user_input>=0)
            {
                if (user_input > max_num)
                {
                    max_num = user_input;
                }
                Console.WriteLine("Enter a Number: ");
                user_input = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Negative number entered application stopped!");
            Console.WriteLine("The maximum of the give number is " + max_num);

        }
    }
}
