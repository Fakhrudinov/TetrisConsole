using System;
using System.Diagnostics;
using System.Text;

namespace ConsoleTetris
{

    class Program
    {
        //set field size
        public static byte x = 13;
        static byte y = 20;
        static byte indentTop = 6;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            //Console.SetBufferSize(50, 60);

            Console.Title = "Tetris";

            Console.WindowHeight = y + 20;
            Console.WindowWidth = x * 2 + 60;

            Console.OutputEncoding = Encoding.UTF8;
            Stopwatch timer = new Stopwatch();

            Console.Clear();

            byte[,] tetris = new byte[y,x];
            tetris[y-1,x-1] = 3;
            tetris[7, 7] = 3;
            tetris[1, 0] = 3;
            tetris[4, 4] = 2;

            Random rand = new Random();            

            Figure figure = new Figure((sbyte)rand.Next(1, 7), tetris);
            //Figure figure = new Figure(1, tetris);
            figure.PaintNewScreen(tetris, figure);
            figure.Display();


            ConsoleKey choice;
            do
            {
                choice = Console.ReadKey(true).Key;

                timer.Restart();
                switch (choice)
                {
                    //case ConsoleKey.UpArrow:
                    case ConsoleKey.X:// rotate ClockWise
                        figure.RotateFigure(true);
                        break;
                    
                    case ConsoleKey.Z:// rotate CounterClockWise
                        figure.RotateFigure(false);
                        break;
                    
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.Spacebar:
                        figure.MoveFigure(0, 1);
                        break;
                    
                    case ConsoleKey.LeftArrow:// move Left
                        figure.MoveFigure(-1, 0);
                        break;
                    
                    case ConsoleKey.RightArrow://move Right
                        figure.MoveFigure(1, 0);
                        break;                   
                }

                Console.SetCursorPosition(0, y + indentTop + 1);
                timer.Stop();
                Console.Write("milliSeconds: " + timer.ElapsedMilliseconds);

            } while (choice != ConsoleKey.Escape);// && choice != ConsoleKey.X
        }

        /*
        private static void PaintNewScreen(byte[,] tetris, Figure figure)
        {
            Console.Clear();

            for (int y = 0; y < tetris.GetLength(0); y++)
            {
                Console.Write("\u2503"); // left border
                for (int x = 0; x < tetris.GetLength(1); x++)
                {
                    Console.ForegroundColor = figure.GetFigureColor((sbyte)tetris[y, x]);

                    Console.Write("\u2588" + x.ToString().Substring(x.ToString().Length - 1));//black square as empty field
                    Console.ResetColor();
                }
                Console.Write("\u2503"); // right border
                Console.WriteLine();
            }

            //generate bottom border
            Console.Write("\u2523");
            for (int i = 0; i < tetris.GetLength(1) * 2; i++)
                Console.Write("\u2501");
            Console.Write("\u252B");
        }
        */
    }
}
/*
Console.WriteLine("" +
    "\u2588\u2588\u2588\u2588\n" +
    "\u2593\u2593\u2593\u2593\n" +
    "\u2592\u2592\u2592\u2592\n" +
    "\u2591\u2591\u2591\u2591");
 * |___
 * ___|
 * _|`
 *`|_
 *_|_
 *
Console.WriteLine("\u250F\u2501\u2501\u2513");
Console.WriteLine("\u2503  \u2503");
Console.WriteLine("\u2503  \u2503");
Console.WriteLine("\u2523\u2501\u2501\u252B");
Console.WriteLine("\u2503  \u2503");
Console.WriteLine("\u2517\u2501\u2501\u251B");
*/

