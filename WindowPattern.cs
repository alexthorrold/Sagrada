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
        public const int ROWS = 5;
        public const int COLUMNS = 4;

        private Tile[,] tileArray;

        public WindowPattern(Dice[,] reqArray)
        {
            tileArray = new Tile[ROWS, COLUMNS];

            tileArray[2, 2] = new Tile(Color.Blue);
            tileArray[3, 3] = new Tile(4);
        }

        public WindowPattern(Tile[,] reqArray, int x, int y)
        {
            if (reqArray.GetLength(0) == 5 && reqArray.GetLength(1) == 4)
                tileArray = reqArray;
            else
                throw new Exception("Array of invalid size received.");

            left = x;
            top = y;
        }

        public Tile[,] TileArray
        {
            get { return tileArray; }
        }

        public void AddDice(Dice d, int row, int column)
        {
            tileArray[row, column].Dice = d;
        }

        public int GetRow(int x)
        {
            return (x - left) / (Dice.DICE_SIZE + PEN_THICKNESS);
        }

        public int GetColumn(int y)
        {
            return (y - top) / (Dice.DICE_SIZE + PEN_THICKNESS);
        }

        public bool IsMouseOn(int x, int y)
        {
            if (x >= left && x <= left + Dice.DICE_SIZE * ROWS + PEN_THICKNESS * (ROWS - 1)
                && y >= top && y <= top + (Dice.DICE_SIZE * COLUMNS + PEN_THICKNESS * (COLUMNS - 1)))
                return true;
            return false;
        }

        public bool PlacementCheck(Dice d, int row, int column)
        {
            //Checks whether there isn't already a dice in 
            bool valid = TileArray[row, column].Dice == null && TileArray[row, column].RequirementCheck(d);

            //Checks number and color of surrounding dice
            //Doesn't check cases where row or column is outside of array bounds
            if (row > 0)
                valid = valid && TileArray[row - 1, column].PlacementCheck(d);
            if (row < 4)
                valid = valid && TileArray[row + 1, column].PlacementCheck(d);
            if (column > 0)
                valid = valid && TileArray[row, column - 1].PlacementCheck(d);
            if (column < 3)
                valid = valid && TileArray[row, column + 1].PlacementCheck(d);

            return valid;
        }

        public override void Draw(Graphics paper)
        {
            Pen pen = new Pen(Color.Black, PEN_THICKNESS);

            paper.DrawRectangle(pen, left - PEN_THICKNESS, top - PEN_THICKNESS, (Dice.DICE_SIZE + PEN_THICKNESS) * ROWS + PEN_THICKNESS, (Dice.DICE_SIZE + PEN_THICKNESS) * COLUMNS + PEN_THICKNESS);

            for (int a = 0; a < ROWS; a++)
            {
                for (int b = 0; b < COLUMNS; b++)
                {
                    tileArray[a, b].Draw(paper, left + (Dice.DICE_SIZE + BoardPiece.PEN_THICKNESS) * a, top + (Dice.DICE_SIZE + BoardPiece.PEN_THICKNESS) * b);
                }
            }
        }
    }
}
