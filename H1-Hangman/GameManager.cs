using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Hangman
{
    internal class GameManager
    {
        public Word Word { get; private set; }
        
        public Player Player { get; private set; }

        public bool IsRunning { get; private set; } = true;

        public bool GameOver { get; private set; } = false;
        public int UsedGuesses { get; private set; } = 0;

        public char[] GuessedChars { get; private set; }

        public GameManager()
        {
            Word = new Word();
            Player = new Player();

            // One char for each of the 28 letters of the english alphabet.
            // Each char starts out as an empty space, and later will be filled
            // out with letters as the player guesses.
            GuessedChars = new char[28]
            {
                ' ',' ',' ',' ',
                ' ',' ',' ',' ',
                ' ',' ',' ',' ',
                ' ',' ',' ',' ',
                ' ',' ',' ',' ',
                ' ',' ',' ',' ',
                ' ',' ',' ',' '
            };
        }

        public GameManager(string word)
        {
            Word = new Word(word);
            Player = new Player();
        }

        public string TakeTurn(char c)
        {
            // Make the char lower case, so users can't guess the same letter twice by guessing e AND E.
            c = Char.ToLower(c);

            // If player hasn't already guessed this letter, add it to the list of letters that has been guessed on.
            if (!GuessedChars.Contains(c))
            {
                GuessedChars[UsedGuesses] = c;
                UsedGuesses++;
            }
            // If the player has already guessed this letter, they won't lose a life, but instead be told to guess a different letter.
            else
            {
                return "You already guessed this letter. Try again.";
            }

            // If the word contains this letter
            if (ContainsLetter(c))
            {
                bool hasUnknownLetters = false; // Check if the word still has unknown letters. // TODO: This could probably be integrated a bit more gracefully.
                for (int i = 0; i < Word.Letters.Length; i++)
                {
                    // Break out of loop if ANY letters is still unknown
                    if (Word.Letters[i].IsKnown == false)
                    {
                        hasUnknownLetters = true;
                    }
                }
                // If all letters are known, the gameloop will stop.
                IsRunning = hasUnknownLetters;

                return c + " was found in the word!";
            }
            // If the word DOESN'T contain this letter
            else
            {
                // Player loses 1 life
                Player.Lives--;
                
                // When player has no more lives, stop the game loop AND set the gameover boolean to false,
                // to indicate that the player has lost.
                if (Player.Lives <= 0)
                {
                    GameOver = true;
                    IsRunning = false;
                }

                return c + " was not found in the word.";
            }
        }

        /// <summary>
        /// Check if the word contains a letter.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool ContainsLetter(char c)
        {
            // Result starts out as false, and gets set to true if the letter is found in the word.
            bool result = false;

            // Check all letters.
            for (int i = 0; i < Word.Letters.Length; i++)
            {
                if (Word.Letters[i].Char == c)
                {
                    // When a match is hit, the letter becomes known and we set result to true.
                    // We don't want to return yet, because if there are multiple instances of the
                    // letter in the word, we need to set all of them to IsKnown = true.
                    Word.Letters[i].IsKnown = true;
                    result = true;
                }
            }

            return result;
        }

        public string PrintAllGuessedChars()
        {
            string result = "";

            for (int i = 0; i < GuessedChars.Length; i++)
            {
                result += GuessedChars[i];
            }

            return result;
        }
    }
}
