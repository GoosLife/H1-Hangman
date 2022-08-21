using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace H1_Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool FLAG_CHEATMODE = false; // Set to true to display the correct word on the top of the screen.

            GameManager gm = new GameManager();

            string result = "";

            while (gm.IsRunning)
            {
                Console.Clear();
                
                if (FLAG_CHEATMODE)
                    Console.WriteLine(gm.Word.GetWord());

                Console.WriteLine(result);

                Console.WriteLine(gm.Player.DrawPlayer());

                Console.WriteLine("Guess a letter: " + gm.Word.ToString());

                Console.WriteLine("\n(Used letters: " + gm.PrintAllGuessedChars() + ')');

                char c = ' ';
                Regex r = new Regex("[A-Za-z]"); // Make sure that the player can only guess letters in the english alphabet

                while (!r.IsMatch(c.ToString()))
                {
                    c = Console.ReadKey().KeyChar;
                }

                // Save the result of the turn to display on top of the screen in the next loop.
                result = gm.TakeTurn(c);
            }

            if (gm.GameOver)
            {
                Console.Clear();
                Console.WriteLine(gm.Player.DrawPlayer());
                Console.WriteLine("You lost. The word was " + gm.Word.GetWord());
            }

            else
            {
                Console.Clear();
                Console.WriteLine(gm.Player.DrawPlayer());
                Console.WriteLine("YOU WON! The word was " + gm.Word.GetWord());
            }
        }
    }
}
