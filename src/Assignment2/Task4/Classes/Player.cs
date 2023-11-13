using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Classes
{
    public class Player
    {
        public char Symbol { get; }

        public Player(char symbol)
        {
            Symbol = symbol;
        }

        public void MakeMove(char[,] board)
        {
            throw new NotImplementedException();
        }
    }
}
