using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sagrada
{
    public class WindowPattern : BoardPiece
    {
        private const int ROWS = 5;
        private const int COLUMNS = 4;

        Dice[,] diceArray;
        Dice[,] requirementArray;

        public WindowPattern(Dice[,] reqArray)
        {
            diceArray = new Dice[ROWS, COLUMNS];

            if (reqArray.GetLength(0) == ROWS && reqArray.GetLength(1) == COLUMNS)
            {
                requirementArray = reqArray;
            }
            else
            {
                throw new Exception("Provided array is not of correct size");
            }

            diceArray[1, 1] = new Dice(Color.Blue, 2);

            //requirementArray = new Dice[ROWS, COLUMNS];

            //requirementArray[0, 1] = new Dice(Color.Gray, 5);
            //requirementArray[0, 1].MoveTo(50, 50 + 99);
            //requirementArray[1, 1] = new Dice(Color.DarkRed, 0);
            //requirementArray[1, 1].MoveTo(50 + 99, 50 + 99);

            //left = x;
            //top = y;
        }

        public Dice[,] DiceArray
        {
            get { return diceArray; }
        }

        //public void AddRequirement(int row, int col, Color c, int i)
        //{
        //    if (row < ROWS && col < COLUMNS)
        //    {
        //        requirementArray[row, col] = new Dice(c, i);
        //    }
        //    else
        //    {
        //        throw new Exception("Row or column is invalid");
        //    }
        //}

        public override bool IsMouseOn(int x, int y)
        {
            if (x > left && x <= left + (DICE_SIZE * ROWS + PEN_THICKNESS * (ROWS - 1)) && y > top && y <= top + (DICE_SIZE * COLUMNS + PEN_THICKNESS * (COLUMNS - 1)))
            {
                int column = (x - left) / (DICE_SIZE + 9);
                int row = (y - top) / (DICE_SIZE + 9);

                Console.WriteLine(column);
                Console.WriteLine(row);
                Console.WriteLine(x - left);
                Console.WriteLine(y - top);

                return true;
            }
            else
            {
                Console.WriteLine("false");
                Console.WriteLine(x);
                Console.WriteLine(y);
                return false;
            }
        }

        public override void Draw(Graphics paper)
        {
            Pen pen = new Pen(Color.Black, PEN_THICKNESS);
            SolidBrush br = new SolidBrush(Color.Yellow);

            paper.DrawRectangle(pen, left - PEN_THICKNESS, top - PEN_THICKNESS, (DICE_SIZE + PEN_THICKNESS) * 5 + PEN_THICKNESS, (DICE_SIZE + PEN_THICKNESS) * 4 + PEN_THICKNESS);

            Dice currentDice;

            int drawX = left;
            int drawY;

            for (int a = 0; a < ROWS; a++)
            {
                drawY = top;

                for (int b = 0; b < COLUMNS; b++)
                {
                    if (DiceArray[a, b] != null)
                    {
                        currentDice = DiceArray[a, b];
                    }
                    else if (requirementArray[a, b] != null)
                    {
                        currentDice = requirementArray[a, b];
                        currentDice.MoveTo(a * (DICE_SIZE + PEN_THICKNESS) + 50, b * (DICE_SIZE + PEN_THICKNESS) + 50);
                    }
                    else
                    {
                        currentDice = new Dice(Color.LightGray, 0);
                        currentDice.MoveTo(a * (DICE_SIZE + PEN_THICKNESS) + 50, b * (DICE_SIZE + PEN_THICKNESS) + 50);
                    }

                    currentDice.Draw(paper);

                    drawY += DICE_SIZE + 9;
                }
                drawX += DICE_SIZE + 9;
            }
        }
    }
}
