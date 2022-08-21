using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Hangman
{
    internal class Player
    {
        public int Lives { get; set; } = 6;

        public string DrawPlayer()
        {
            switch (Lives)
            {
                case 6:
                    return
                        "   +---+   " + '\n' +
                        "   |   |   " + '\n' +
                        "       |   " + '\n' +
                        "       |   " + '\n' +
                        "       |   " + '\n' +
                        "       |   " + '\n' +
                        " ========= ";
                case 5:
                    return
                        "   +---+   " + '\n' +
                        "   |   |   " + '\n' +
                        "   O   |   " + '\n' +
                        "       |   " + '\n' +
                        "       |   " + '\n' +
                        "       |   " + '\n' +
                        " ========= ";
                case 4:
                    return 
                        "   +---+   " + '\n' +
                        "   |   |   " + '\n' +
                        "   O   |   " + '\n' +
                        "   |   |   " + '\n' +
                        "       |   " + '\n' +
                        "       |   " + '\n' +
                        " ========= ";
                case 3:
                    return
                        "   +---+   " + '\n' +
                        "   |   |   " + '\n' +
                        "   O   |   " + '\n' +
                        "  /|   |   " + '\n' +
                        "       |   " + '\n' +
                        "       |   " + '\n' +
                        " ========= ";
                case 2:
                    return
                        "   +---+   " + '\n' +
                        "   |   |   " + '\n' +
                        "   O   |   " + '\n' +
                       @"  /|\  |   " + '\n' +
                        "       |   " + '\n' +
                        "       |   " + '\n' +
                        " ========= ";
                case 1:
                    return
                        "   +---+   " + '\n' +
                        "   |   |   " + '\n' +
                        "   O   |   " + '\n' +
                       @"  /|\  |   " + '\n' +
                        "  /    |   " + '\n' +
                        "       |   " + '\n' +
                        " ========= ";
                case 0:
                    return
                        "   +---+   " + '\n' +
                        "   |   |   " + '\n' +
                        "   O   |   " + '\n' +
                       @"  /|\  |   " + '\n' +
                       @"  / \  |   " + '\n' +
                        "       |   " + '\n' +
                        " ========= ";
                default:
                    return "Player is dead or has too many lives somehow.";
            }
        }
    }
}
