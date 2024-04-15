namespace CowBull
{
    internal class Program
    {
        /// <summary>
        /// Starts the game
        /// </summary>
        void startGame()
        {
            Console.WriteLine("Game has started.");
            Console.Write("Player 1 enter target word of 4 char: ");
            string target = Console.ReadLine();
           
            if(target.Length==4) 
            {
                Console.WriteLine("Player 2 Guess the word within 15 attempts");
                int atempts = 15;

                while (atempts > 0)
                {
                    Console.WriteLine ("Atttempt: "+atempts);
                    Console.WriteLine("Guess the word: ");
                    string guess = Console.ReadLine();
                    if (guess.Length != 4)
                    {
                        Console.WriteLine("Only 4 chars allowed. Invalid input");
                        continue;
                    }
                    Console.WriteLine("Cow - "+cow(target,guess)+" Bull - "+bull(target,guess));
                    if (guess == target)
                    {
                        Console.WriteLine("Congrats You Won");
                        return;
                    }
                    atempts--;
                }
                Console.WriteLine("You loose you have exhausted your attempts");
            }
            else
            {
                Console.WriteLine("Only 4 chars allowed. Invalid input");
            }
            
        }

        /// <summary>
        /// checks for cow part. Same char same position
        /// </summary>
        /// <param name="target">Target word</param>
        /// <param name="guess">Guessed word</param>
        /// <returns>no.of cow in the guessed word</returns>
        int cow(string target,string guess)
        {
            int count = 0;
            for(int i = 0;i<4;i++)
            {
                if (target[i] == guess[i])
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Returns the bull part of the game. Same char diff position.
        /// </summary>
        /// <param name="target">Target word</param>
        /// <param name="guess">Guessed word</param>
        /// <returns>Bull count</returns>
        int bull(string target,string guess)
        {
            int count = 0;
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (target[i] == guess[j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.startGame();

       
        }
    }
}
