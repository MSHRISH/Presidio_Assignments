using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidCardNumber
{
    internal class Program
    {
        /// <summary>
        /// A function that intakes the card number and checks if it is valid or not
        /// </summary>
        /// <param name="cardNumber">16 digit card number</param>
        /// <returns>true if it is valid and false if it is not valid.</returns>
        static bool validateCard(long cardNumber)
        {
            string cardNumberString = Convert.ToString(cardNumber);
            //Console.WriteLine(cardNumberString);
            if(cardNumber< 9999999999999999 && cardNumber > 0)
            {
                bool oddflag=true;
                int ans = 0;
                for(int i = 0; i < 16; i++)
                {
                    int lastDigit = Convert.ToInt16(cardNumber % 10);
                    cardNumber = cardNumber / 10;

                    //Console.WriteLine("Digit: "+lastDigit);

                    if (oddflag)
                    {
                        ans += lastDigit;
                        oddflag = false;
                    }
                    else
                    {
                        int multipleOfTwo = lastDigit * 2;
                        if (multipleOfTwo > 9)
                        {
                            int singleDigitConvert = multipleOfTwo % 10;
                            multipleOfTwo = multipleOfTwo / 10;
                            singleDigitConvert += multipleOfTwo;
                            multipleOfTwo = singleDigitConvert;
                        }
                        ans += multipleOfTwo;
                        oddflag=true;
                    }



                }
                //Console.WriteLine(ans);
                if (ans % 10 == 0)
                {
                    return true;
                }
            }

            
            
            return false;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter a 16 Digit Card Number: ");
            long cardNumber=Convert.ToInt64(Console.ReadLine());
            if (validateCard(cardNumber))
            {
                Console.WriteLine("The given card number is valid");
            }
            else
            {
                Console.WriteLine("The given card number is not valid");
            }

        }
    }
}
