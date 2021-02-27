using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace ConsoleTetris
{

    class Program
    {
        //set field size
        static byte x = 13;
        static byte y = 20;
        //static byte indentTop = 2;

        //static byte[,] tetris = new byte[y, x];
        //static Figure figure = new Figure(tetris);
        static Figure figure = new Figure();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            //Console.SetBufferSize(50, 60);

            Console.Title = "Tetris";

            Console.WindowHeight = y + 5;
            Console.WindowWidth = x * 2 + 4;

            Console.OutputEncoding = Encoding.UTF8;
            
            //Stopwatch timer = new Stopwatch();

            Console.Clear();


            figure.PaintNewScreen();
            figure.Display();
            Timer timerTick = new Timer(timerMove, null, 0, 1000);

            ConsoleKey choice;
            do
            {
                choice = Console.ReadKey(true).Key;

                //timer.Restart();
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
                        if (figure.CanMove)
                            figure.MoveFigure(0, 1);
                        break;
                    
                    case ConsoleKey.LeftArrow:// move Left
                        figure.MoveFigure(-1, 0);
                        break;
                    
                    case ConsoleKey.RightArrow://move Right
                        figure.MoveFigure(1, 0);
                        break;                   
                }

                //Console.SetCursorPosition(0, y + indentTop);
                //timer.Stop();
                //Console.Write("milliSeconds: " + timer.ElapsedMilliseconds);
                //Console.Write(" bH=" + Console.BufferHeight);
                //Console.Write(" bW=" + Console.BufferWidth);

            } while (choice != ConsoleKey.Escape);// && choice != ConsoleKey.X
        }

        static void timerMove(Object obj)
        {
            if(figure.CanMove)
                figure.MoveFigure(0, 1);

            //timerTick.Change(0, 500);
        }
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

