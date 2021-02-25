using System;

namespace ConsoleTetris
{
    public class Class1
    {
        public static ConsoleColor GetFigureColor(byte type)
        {
            //Set Figure Color
            switch (type)
            {
                case 1:
                case 11:
                    return ConsoleColor.Red;
                    break;
                case 2:
                    return ConsoleColor.Green;
                    break;
                case 3:
                case 13:
                case 23:
                case 33:
                    return ConsoleColor.Blue;
                    break;
                case 4:
                case 14:
                case 24:
                case 34:
                    return ConsoleColor.Magenta;
                    break;
                case 5:
                case 15:
                case 25:
                case 35:
                    return ConsoleColor.White;
                    break;
                case 6:
                case 16:
                case 26:
                case 36:
                    return ConsoleColor.Yellow;
                    break;
                case 7:
                case 17:
                case 27:
                case 37:
                    return ConsoleColor.Cyan;
                    break;
            }

            return ConsoleColor.White;
        }
    }
}
