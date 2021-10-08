﻿using System;
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

        private Dice[,] diceArray;
        private Dice[,] requirementArray;

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

            //diceArray[1, 1] = new Dice(Color.Blue, 2);

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

        public void ClickCheck(int x, int y)
        {
            if (x >= left && x <= left + DICE_SIZE * ROWS + PEN_THICKNESS * (ROWS - 1) && y >= top && y <= top + (DICE_SIZE * COLUMNS + PEN_THICKNESS * (COLUMNS - 1)))
            {
                int row = (x - left) / (DICE_SIZE + PEN_THICKNESS);
                int column = (y - top) / (DICE_SIZE + PEN_THICKNESS);

                DiceArray[row, column] = new Dice(Color.Blue, 3, left + row * (DICE_SIZE + PEN_THICKNESS), top + column * (DICE_SIZE + PEN_THICKNESS));
            }
        }

        public void MoveTo(int x, int y)
        {
            left = x;
            top = y;

            int xPos = left;
            int yPos;

            for (int a = 0; a < ROWS; a++)
            {
                yPos = top;

                for (int b = 0; b < COLUMNS; b++)
                {
                    if (DiceArray[a, b] != null)
                    {
                        DiceArray[a, b].MoveTo(a * (DICE_SIZE + PEN_THICKNESS) + 50, b * (DICE_SIZE + PEN_THICKNESS) + 50);
                    }
                    else if (requirementArray[a, b] != null)
                    {
                        requirementArray[a, b].MoveTo(a * (DICE_SIZE + PEN_THICKNESS) + 50, b * (DICE_SIZE + PEN_THICKNESS) + 50);
                    }

                    yPos += DICE_SIZE + PEN_THICKNESS;
                }
                xPos += DICE_SIZE + PEN_THICKNESS;
            }
        }

        public override void Draw(Graphics paper)
        {
            Pen pen = new Pen(Color.Black, PEN_THICKNESS);

            paper.DrawRectangle(pen, left - PEN_THICKNESS, top - PEN_THICKNESS, (DICE_SIZE + PEN_THICKNESS) * ROWS + PEN_THICKNESS, (DICE_SIZE + PEN_THICKNESS) * COLUMNS + PEN_THICKNESS);

            Dice currentDice;

            int x = left;
            int y;

            for (int a = 0; a < ROWS; a++)
            {
                y = top;

                for (int b = 0; b < COLUMNS; b++)
                {
                    if (DiceArray[a, b] != null)
                    {
                        currentDice = DiceArray[a, b];
                    }
                    else if (requirementArray[a, b] != null)
                    {
                        currentDice = requirementArray[a, b];
                        currentDice.MoveTo(a * (DICE_SIZE + PEN_THICKNESS) + left, b * (DICE_SIZE + PEN_THICKNESS) + top);
                    }
                    else
                    {
                        currentDice = new Dice(Color.LightGray, 0, a * (DICE_SIZE + PEN_THICKNESS) + left, b * (DICE_SIZE + PEN_THICKNESS) + top);
                    }

                    currentDice.Draw(paper);

                    y += DICE_SIZE + PEN_THICKNESS;
                }
                x += DICE_SIZE + PEN_THICKNESS;
            }
        }
    }
}
