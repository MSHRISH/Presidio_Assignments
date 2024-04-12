using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App
{
    internal class question1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Number:");
            int a= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Another Number:");
            int b= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Sum="+add(a,b));
            Console.WriteLine("Product="+product(a,b));
            Console.WriteLine("Divide="+divide(a,b));   
            Console.WriteLine("sub="+sub(a,b));
            Console.WriteLine("Remainder=" + remainder(a, b));
        }

        static int add(int a, int b)
        {
            return a + b;
        }

        static int product(int a, int b)
        {
            return a * b;
        }

        static int divide (int a, int b)
        {
            return a / b;
        }

        static int sub(int a, int b)
        {
            return a - b;
        }

        static int remainder(int a, int b)
        {
            return a % b;
        }
    }
}
