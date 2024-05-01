using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    public class Question3
    {
        
        public static async Task<bool> HasCycle(LinkedList Head)
        {
            HashSet<LinkedList> visited = new HashSet<LinkedList>();
            while (Head != null)
            {
                if (visited.Contains(Head))
                {
                    return true;
                }

                visited.Add(Head);
                Head = Head.Next;
            }
            return false;
        }
        static void Main(string[] args)
        {
            
        }
    }
}
