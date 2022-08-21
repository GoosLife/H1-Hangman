using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Hangman
{
    internal class Letter
    {
        public char Char { get; set; }
        public bool IsKnown { get; set; } = false;

        public Letter(char c)
        {
            Char = c;
        }
    }
}
