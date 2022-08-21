using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Hangman
{
    internal class Word
    {
        public Letter[] Letters { get; set; }

        public Word()
        {
            // Get a long string containing all words, and split it into an array of separate words
            string wordlist = File.ReadAllText(Directory.GetCurrentDirectory() + "\\wordlist.txt");
            string[] words = wordlist.Split("\r\n");

            // Pick a random word from the array
            Random r = new Random();
            int wordIndex = r.Next(words.Length);

            // Save the chosen word in a string
            string word = words[wordIndex];

            // Initialize letters
            Letters = new Letter[word.Length];

            // Create the letters so we have a way of keeping track of both the char and whether a letter is currently known
            InitLetters(word);
        }

        public Word(string word)
        {
            // Create letters
            Letters = new Letter[word.Length];
            InitLetters(word);
        }
        
        // Save each character of a string as a letter in the word.
        public void InitLetters(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                Letters[i] = new Letter(word[i]);
            }
        }

        /// <summary>
        /// Return the plaintext word without having guessed all the letters.
        /// </summary>
        /// <returns></returns>
        public string GetWord()
        {
            string result = "";
            
            for (int i = 0; i < Letters.Length; i++)
            {
                result += Letters[i].Char;
            }

            return result;
        }

        // Output the word, but replace unknown letters with underscores.
        public override string ToString()
        {
            string output = "";

            for (int i = 0; i < Letters.Length; i++)
            {
                if (Letters[i].IsKnown)
                {
                    output += Letters[i].Char + " ";
                }
                else
                {
                    output += "_ ";
                }
            }

            return output;
        }
    }
}
