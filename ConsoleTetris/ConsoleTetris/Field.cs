using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTetris
{
    class Field
    {
        public byte[,] TetrisField { get; set; }

        public Field()
        {
            TetrisField = new byte[20, 15];
        }

    }
}
