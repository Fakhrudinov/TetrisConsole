using System;

namespace ConsoleTetris
{
    class Figure
    {
        public Random Rand = new Random();

        private sbyte Type { get; set; }

        private int PosX { get; set; }
        private int PosY { get; set; }

        private ConsoleColor Color { get; set; }
        private byte[,] Tetris { get; set; }

        private byte[,] FigureShape { get; set; }

        public sbyte Frequency { get; set; }

        public bool CanMove { get; set; } = true;

        public Figure(byte[,] tetris)
        {
            Field f = new Field();
            Tetris = f.TetrisField;

            ResetFigure();
        }

        public Figure()
        {
            Field f = new Field();
            Tetris = f.TetrisField;

            ResetFigure();
        }

        private void ResetFigure()
        {
            Type = (sbyte)Rand.Next(1, 7);
            Color = GetFigureColor(Type);
            FigureShape = GetFigureShape(Type);
            PosX = Tetris.GetLength(1) / 2;
            PosY = 0;
        }

        public ConsoleColor GetFigureColor(sbyte type)
        {
            //Set Figure Color
            switch (type)
            {
                case 0:
                    return ConsoleColor.Black;

                case 1:
                case 11:
                case 21:
                case 31:
                    return ConsoleColor.Red;

                case 2:
                case 12:
                case 22:
                case 32:
                    return ConsoleColor.Green;

                case 3:
                case 13:
                case 23:
                case 33:
                    return ConsoleColor.Blue;

                case 4:
                case 14:
                case 24:
                case 34:
                    return ConsoleColor.Magenta;

                case 5:
                case 15:
                case 25:
                case 35:
                    return ConsoleColor.White;

                case 6:
                case 16:
                case 26:
                case 36:
                    return ConsoleColor.Yellow;

                case 7:
                case 17:
                case 27:
                case 37:
                    return ConsoleColor.Cyan;
            }

            return ConsoleColor.White;
        }

        private byte[,] GetFigureShape(sbyte type)
        {
            int fullX = Tetris.GetLength(1); // set short name for column lenght
            int midlX = Tetris.GetLength(1) / 2; // set short name for middle X axis of array
            byte[,] newShape = new byte[2, fullX];

            // set figure shape
            switch (type)
            {
                //
                // ####
                case 1:
                    newShape = new byte[2, fullX];
                    newShape[1, midlX - 1] = 1;
                    newShape[1, midlX] = 1;
                    newShape[1, midlX + 1] = 1;
                    newShape[1, midlX + 2] = 1;
                    break;

                //  #
                //  #
                //  #
                //  #
                case 11:
                    newShape = new byte[4, fullX];
                    newShape[0, midlX + 1] = 1;
                    newShape[1, midlX + 1] = 1;
                    newShape[2, midlX + 1] = 1;
                    newShape[3, midlX + 1] = 1;
                    break;

                //
                //
                // ####
                case 21:
                    newShape = new byte[3, fullX];
                    newShape[2, midlX - 1] = 1;
                    newShape[2, midlX] = 1;
                    newShape[2, midlX + 1] = 1;
                    newShape[2, midlX + 2] = 1;
                    break;

                // #
                // #
                // #
                // #
                case 31:
                    newShape = new byte[4, fullX];
                    newShape[0, midlX] = 1;
                    newShape[1, midlX] = 1;
                    newShape[2, midlX] = 1;
                    newShape[3, midlX] = 1;
                    break;

                // ##
                // ##
                case 2:
                case 12:
                case 22:
                case 32:
                    newShape = new byte[2, fullX];
                    newShape[0, midlX + 1] = 1;
                    newShape[0, midlX] = 1;
                    newShape[1, midlX + 1] = 1;
                    newShape[1, midlX] = 1;
                    break;

                // ##
                //  ##
                case 3:
                case 23:
                    newShape = new byte[2, fullX];
                    newShape[0, midlX - 1] = 1;
                    newShape[0, midlX] = 1;
                    newShape[1, midlX] = 1;
                    newShape[1, midlX + 1] = 1;
                    break;

                //  #
                // ##
                // # 
                case 13:
                case 33:
                    newShape = new byte[3, fullX];
                    newShape[0, midlX + 1] = 1;
                    newShape[1, midlX] = 1;
                    newShape[1, midlX + 1] = 1;
                    newShape[2, midlX] = 1;
                    break;

                //  #
                // ###
                case 4:
                    newShape = new byte[2, fullX];
                    newShape[0, midlX] = 1;
                    newShape[1, midlX - 1] = 1;
                    newShape[1, midlX] = 1;
                    newShape[1, midlX + 1] = 1;
                    break;

                // #
                // ##
                // #
                case 14:
                    newShape = new byte[3, fullX];
                    newShape[0, midlX] = 1;
                    newShape[1, midlX] = 1;
                    newShape[1, midlX + 1] = 1;
                    newShape[2, midlX] = 1;
                    break;

                // ###
                //  #
                case 24:
                    newShape = new byte[2, fullX];
                    newShape[0, midlX - 1] = 1;
                    newShape[0, midlX] = 1;
                    newShape[0, midlX + 1] = 1;
                    newShape[1, midlX] = 1;
                    break;

                //  #
                // ##
                //  #
                case 34:
                    newShape = new byte[3, fullX];
                    newShape[0, midlX] = 1;
                    newShape[1, midlX] = 1;
                    newShape[1, midlX - 1] = 1;
                    newShape[2, midlX] = 1;
                    break;

                //  ##
                // ##
                case 5:
                case 25:
                    newShape = new byte[2, fullX];
                    newShape[0, midlX] = 1;
                    newShape[0, midlX + 1] = 1;
                    newShape[1, midlX - 1] = 1;
                    newShape[1, midlX] = 1;
                    break;

                // #
                // ##
                //  # 
                case 15:
                case 35:
                    newShape = new byte[3, fullX];
                    newShape[0, midlX] = 1;
                    newShape[1, midlX] = 1;
                    newShape[1, midlX + 1] = 1;
                    newShape[2, midlX + 1] = 1;
                    break;

                // ##
                // #
                // # 
                case 6:
                    newShape = new byte[3, fullX];
                    newShape[0, midlX] = 1;
                    newShape[0, midlX + 1] = 1;
                    newShape[1, midlX] = 1;
                    newShape[2, midlX] = 1;
                    break;

                // ###
                //   #
                case 16:
                    newShape = new byte[2, fullX];
                    newShape[0, midlX - 1] = 1;
                    newShape[0, midlX] = 1;
                    newShape[0, midlX + 1] = 1;
                    newShape[1, midlX + 1] = 1;
                    break;

                //  #
                //  #
                // ## 
                case 26:
                    newShape = new byte[3, fullX];
                    newShape[0, midlX] = 1;
                    newShape[1, midlX] = 1;
                    newShape[2, midlX] = 1;
                    newShape[2, midlX - 1] = 1;
                    break;

                // #
                // ###
                case 36:
                    newShape = new byte[2, fullX];
                    newShape[0, midlX - 1] = 1;
                    newShape[1, midlX - 1] = 1;
                    newShape[1, midlX] = 1;
                    newShape[1, midlX + 1] = 1;
                    break;

                // ##
                //  #
                //  # 
                case 7:
                    newShape = new byte[3, fullX];
                    newShape[0, midlX -1] = 1;
                    newShape[0, midlX] = 1;
                    newShape[1, midlX] = 1;
                    newShape[2, midlX] = 1;
                    break;

                //   #
                // ###
                case 17:
                    newShape = new byte[2, fullX];
                    newShape[0, midlX + 1] = 1;
                    newShape[1, midlX - 1] = 1;
                    newShape[1, midlX] = 1;
                    newShape[1, midlX + 1] = 1;
                    break;

                // #
                // #
                // ##
                case 27:
                    newShape = new byte[3, fullX];
                    newShape[0, midlX] = 1;
                    newShape[1, midlX] = 1;
                    newShape[2, midlX] = 1;
                    newShape[2, midlX + 1] = 1;
                    break;

                // ###
                // #
                case 37:
                    newShape = new byte[2, fullX];
                    newShape[0, midlX - 1] = 1;
                    newShape[0, midlX] = 1;
                    newShape[0, midlX + 1] = 1;
                    newShape[1, midlX - 1] = 1;
                    break;

                // 5 * 11+2
                // ### #  # ###
                //  #  #  # #
                //  #  #### ###
                //  #  #  # #
                //  #  #  # ###
                //
                // ### #  # ##
                // #   ## # # #
                // ### # ## #  # 
                // #   #  # # #
                // ### #  # ##
            }

            return newShape;
        }

        public void PaintNewScreen()
        {
            Console.Clear();

            for (int y = 0; y < Tetris.GetLength(0); y++)
            {
                Console.ResetColor();
                Console.Write("\u2503"); // left border
                for (int x = 0; x < Tetris.GetLength(1); x++)
                {
                    Console.ForegroundColor = GetFigureColor((sbyte)Tetris[y, x]);

                    Console.Write("\u2588\u2588");
                    //Console.Write("\u2588" + x.ToString().Substring(x.ToString().Length - 1));//black square as empty field
                    Console.ResetColor();
                }
                Console.Write("\u2503"); // right border
                Console.WriteLine();
            }

            //generate bottom border
            Console.Write("\u2523");
            for (int i = 0; i < Tetris.GetLength(1) * 2; i++)
                Console.Write("\u2501");
            Console.Write("\u252B");
        }

        public void RotateFigure(bool DirectionClockWise)
        {
            int PosXold = PosX;// save previous X
            int PosYold = PosY;// save previous Y
            ConsoleColor ColorDefault = Color; // save previous Color
            bool blockMove = false;
            sbyte oldType = Type;

            //delete old figure paint
            Color = ConsoleColor.Black;
            Display();

            if (DirectionClockWise) //rotate clockWise
            {
                Type = (sbyte)(Type + 10);
                if (Type > 40)
                    Type = (sbyte)(Type - 40);
            }
            else //rotate counter clockWise
            {
                Type = (sbyte)(Type - 10);
                if (Type < 0)
                    Type = (sbyte)(Type + 40);
            }

            byte[,] newFigureShape = GetFigureShape(Type);

            int shiftX = PosX - (Tetris.GetLength(1) / 2);
            newFigureShape = ShiftBytes(newFigureShape, ref shiftX);

            blockMove = CheckCellIsBusy(newFigureShape, Tetris, PosY);
            if (!blockMove)
            {
                FigureShape = newFigureShape.Clone() as byte[,];
            }
            else
            {
                Type = oldType;
            }                
            
            Color = ColorDefault;
            Display();
        }

        public byte[,] ShiftBytes(byte[,] figure, ref int shift)
        {
            bool blockMove = true;
            int canShift = 0;

            //Calculate max shift walue
            if (shift > 0)// -->
            {
                for (int i = 1; i <= shift; i++)
                {
                    for (int row = 0; row < figure.GetLength(0); row++)//rows count
                    {
                        if (figure[row, figure.GetLength(1) - i] != 0)// if all 0 in all rows at this cell position
                        {
                            blockMove = false;
                        }
                    }
                    if (blockMove)//if has empty space before wall
                        canShift++;
                }
            }
            else if (shift < 0) // <--
            {
                for (int i = 0; i < shift * -1; i++)
                {
                    for (int row = 0; row < figure.GetLength(0); row++)//rows count
                    {
                        if (figure[row, i] != 0)// if all 0 in all rows at this cell position
                        {
                            blockMove = false;
                        }
                    }
                    if (blockMove)//if has empty space before wall
                        canShift--;
                }
            }

            shift = canShift;

            //move at calculated canShift value
            if (canShift > 0) // -->
            {
                for (int row = 0; row < figure.GetLength(0); row++)
                {
                    for (int cell = (figure.GetLength(1) - 1) - canShift; cell >= 0; cell--)
                    {
                        figure[row, cell + canShift] = figure[row, cell];
                        figure[row, cell] = 0;
                    }
                }
            }
            if (canShift < 0) // <--
            {
                canShift = canShift * -1;
                for (int row = 0; row < figure.GetLength(0); row++)
                {
                    for (int cell = 0; cell < figure.GetLength(1) - canShift; cell++)
                    {
                        figure[row, cell] = figure[row, cell + canShift];
                        figure[row, cell + canShift] = 0;
                    }
                }
            }

            return figure;
        }

        public void MoveFigure(int shiftX, sbyte shiftY)
        {
            bool blockMove = false;

            ConsoleColor ColorDefault = Color; // save previous Color
            int PosYold = PosY;// save previous Y
            byte[,] newFigureShape = FigureShape.Clone() as byte[,];

            //delete old figure paint
            Color = ConsoleColor.Black;
            Display();

            //paint new figure   
            if (shiftX != 0)
            {
                newFigureShape = ShiftBytes(newFigureShape, ref shiftX);

                if (shiftX != 0)
                {
                    blockMove = CheckCellIsBusy(newFigureShape, Tetris, PosY);

                    if (!blockMove)
                    {
                        FigureShape = newFigureShape.Clone() as byte[,];
                        PosX = PosX + shiftX;
                    }
                }
            }
            
            if (shiftY > 0) //shift down
            {
                if (PosY + FigureShape.GetLength(0) < Tetris.GetLength(0))// check bottom
                {
                    PosY = PosY + shiftY;

                    blockMove = CheckCellIsBusy(newFigureShape, Tetris, PosY);//check bysy cells

                    if (blockMove)
                    {
                        PosY = PosYold;
                        FigureAtBottom();
                    }
                }
                else // already at bottom
                {
                    FigureAtBottom();
                }
            }

            Color = GetFigureColor(Type);
            Display();
        }

        private void FigureAtBottom()
        {
            SaveFigureAtTetris(FigureShape, PosY);

            RemoveFullRows();

            PaintNewScreen();

            ResetFigure();

            bool isThisEndOfGame = CheckCellIsBusy(FigureShape, Tetris, PosY);
            if (isThisEndOfGame)
            {
                CanMove = false;
            }
        }

        private void RemoveFullRows()
        {
            for (int row = Tetris.GetLength(0) - 1; row >= 0; row--)
            {
                bool needAction = true;
                for (int cell = 0; cell < Tetris.GetLength(1); cell++)
                {
                    if (Tetris[row, cell] == 0)//if row not fullfilled
                    {
                        needAction = false;
                        break;
                    }
                }

                if (needAction)
                {
                    Array.Copy(Tetris, 0, Tetris, Tetris.GetLength(1), Tetris.GetLength(1) * row);

                    //top line must be filled 0 - delete old copied data
                    for (int cell = 0; cell < Tetris.GetLength(1); cell++)
                    {
                        Tetris[0, cell] = 0;
                    }
                    RemoveFullRows();
                }
            }
        }

        private void SaveFigureAtTetris(byte[,] figure, int posY)
        {
            sbyte type = Type;

            for (int row = 0; row < figure.GetLength(0); row++)
            {
                for (int cell = 0; cell < figure.GetLength(1); cell++)
                {
                    if (figure[row, cell] != 0)
                    {
                        Tetris[row + posY, cell] = (byte)type;
                    }
                }
            }
        }

        /// <summary>
        /// Check for future instanse of figure make cross with old docked figures
        /// </summary>
        /// <param name="newFigureShape">future instans of array</param>
        /// <param name="tetris">all field with docked figures</param>
        /// <param name="posY">row number</param>
        /// <returns></returns>
        private bool CheckCellIsBusy(byte[,] newFigureShape, byte[,] tetris, int posY)
        {
            bool result = false;

            for (int rows = 0; rows < newFigureShape.GetLength(0); rows++) 
            {
                for (int cell = 0; cell < Tetris.GetLength(1); cell++)
                {
                    if (posY + rows >= Tetris.GetLength(0))//if new figure try to display below y axis of tetris array
                    {
                        result = true;
                        return result;
                    }

                    if (Tetris[posY + rows, cell] > 0 && newFigureShape[rows, cell] > 0)//if cell is busy
                    {
                        result = true;
                        return result;
                    }
                }
            }

            return result;
        }

        public void Display()
        {
            Console.ForegroundColor = Color;

            for (int y = 0; y < FigureShape.GetLength(0); y++)
            {
                for (int x = 0; x < FigureShape.GetLength(1); x++)
                {
                    if (FigureShape[y, x] != 0)
                    {
                        Console.SetCursorPosition(x * 2 + 1, y + PosY);// x*2 + 1 where 1 is a border size
                        Console.Write("\u2588\u2588");
                    }
                }
                Console.WriteLine();
            }

            //info block
            //Console.SetCursorPosition(0, Tetris.GetLength(0) + 1);            
            //Console.Write($"\n{Type}.{Color}   x={PosX}/{Tetris.GetLength(1) / 2} y={PosY} \n");

           /*
            for (int y = 0; y < FigureShape.GetLength(0); y++)
            {
                Console.SetCursorPosition(0, Tetris.GetLength(0) + 3 + y);
                for (int x = 0; x < FigureShape.GetLength(1); x++)
                {
                    Console.Write(FigureShape[y, x]);
                }
                //Console.SetCursorPosition(0, Tetris.GetLength(0) + 4);
            }
           */
        }
    }
}
