using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    
    public  class Question2
    {
        static async Task<int> GetColumnNumber()
        {
            int ColumnNumber;
            Console.WriteLine("Enter Column Number: ");
            ColumnNumber = Convert.ToInt32(Console.ReadLine());
            return ColumnNumber;
        }
        static async Task<string> GetColumnTitle(int ColumnNumber)
        {
            string ans = "";

            while (ColumnNumber > 0)
            {
                int Mod = (ColumnNumber - 1) % 26;
                char c = (char)('A' + Mod);
                ans =c+ans;
                ColumnNumber=(ColumnNumber - 1) /26;
            }
            return ans;
        }
        static async Task Main(string[] args)
        {
            int ColumnNumber = await GetColumnNumber();
            string result = await GetColumnTitle(ColumnNumber);
            Console.WriteLine(result);

        }
    }
}
