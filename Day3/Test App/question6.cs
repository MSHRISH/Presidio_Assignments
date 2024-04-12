using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App
{
    internal class question6
    {
        static int returnVowelCount(string word)
        {
            int count = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == 'a' || word[i] == 'e'|| word[i] == 'i'|| word[i]=='o' || word[i]=='u')
                {
                    count++;
                }
            }
            return count;
        }

        static void leastVowelWords(string[] words)
        {
            List<string> ans= new List<string>();
            int wordCount = 0;
            int minVowels = 0;

            for(int i = 0;i < words.Length;i++)
            {
                if (i == 0)
                {
                    ans.Add(words[i]);
                    minVowels = returnVowelCount(words[i]);
                    wordCount++;
                    continue;
                }

                int vowels = returnVowelCount(words[i]);
                if(vowels<minVowels)
                {
                    ans.Clear();
                    wordCount = 1;
                    minVowels = vowels;
                    ans.Add(words[i]);
                }
                else if(vowels == minVowels)
                {
                    wordCount++;
                    ans.Add(words[i]);
                }
            }

            Console.WriteLine("Least Vowels Words: ");
            foreach(string word in ans) 
            {
                Console.WriteLine(word);
            }


        }
        static void Main(string[] args)
        {
            Console.Write("Enter a coma separated words as input:");
            string[] userInput=Console.ReadLine().Split(',');
            leastVowelWords(userInput);

        }
    }
}
