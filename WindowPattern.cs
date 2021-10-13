using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sagrada
{
    public class WindowPattern : InteractiveBoardPiece
    {
        public const int ROWS = 5;
        public const int COLUMNS = 4;

        private Tile[,] tileArray;

        bool isFirstDice = true;

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

        public bool IsFirstDice
        {
            get { return isFirstDice; }
            set { isFirstDice = value; }
        }

        public int WhiteSpaces
        {
            get
            {
                int i = 0;

                foreach (Tile t in tileArray)
                    if (t.Dice == null)
                        i++;

                return i;
            }
        }

        public void AddDice(Dice d, int row, int column)
        {
            tileArray[row, column].Dice = d;
        }

        public void RemoveDice(int row, int column)
        {
            tileArray[row, column].Dice = null;
        }

        public int GetRow(int x)
        {
            return (x - left) / (Dice.DICE_SIZE + PEN_THICKNESS);
        }

        public int GetColumn(int y)
        {
            return (y - top) / (Dice.DICE_SIZE + PEN_THICKNESS);
        }

        public override bool IsMouseOn(int x, int y)
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
            bool hasTouchingDie = false;

            if (isFirstDice)
            {
                valid = valid && (row == 0 || row == ROWS - 1 || column == 0 || column == COLUMNS - 1);
                
                //The first die doesn't require an adjacent die
                hasTouchingDie = true;
            }

            //Checks number, color of surrounding dice and whether the die is placed next to at least one other die
            //Doesn't check cases where row or column is outside of array bounds
            if (row > 0)
            {
                valid = valid && TileArray[row - 1, column].PlacementCheck(d);
                hasTouchingDie = hasTouchingDie || TileArray[row - 1, column].Dice != null;

                //Checks diagonal edge cases where inside array bounds
                if (column > 0)
                    hasTouchingDie = hasTouchingDie || TileArray[row - 1, column - 1].Dice != null;
                if (column < 3)
                    hasTouchingDie = hasTouchingDie || TileArray[row - 1, column + 1].Dice != null;
            }
            if (row < 4)
            {
                valid = valid && TileArray[row + 1, column].PlacementCheck(d);
                hasTouchingDie = hasTouchingDie || TileArray[row + 1, column].Dice != null;

                //Checks diagonal edge cases where inside array bounds
                if (column > 0)
                    hasTouchingDie = hasTouchingDie || TileArray[row + 1, column - 1].Dice != null;
                if (column < 3)
                    hasTouchingDie = hasTouchingDie || TileArray[row + 1, column + 1].Dice != null;
            }
            if (column > 0)
            {
                valid = valid && TileArray[row, column - 1].PlacementCheck(d);
                hasTouchingDie = hasTouchingDie || TileArray[row, column - 1].Dice != null;
            }
            if (column < 3)
            {
                valid = valid && TileArray[row, column + 1].PlacementCheck(d);
                hasTouchingDie = hasTouchingDie || TileArray[row, column + 1].Dice != null;
            }

            return valid && hasTouchingDie;
        }

        public bool IsPlaceable(Dice d)
        {
            bool isPlaceable = false;

            for (int a = 0; a < ROWS && !isPlaceable; a++)
            {
                for (int b = 0; b < COLUMNS && !isPlaceable; b++)
                {
                    if (tileArray[a, b].Dice != null)
                    {
                        isPlaceable = PlacementCheck(tileArray[a, b].Dice, a, b);
                    }
                }
            }

            return isPlaceable;
        }

        public override void Draw(Graphics paper)
        {
            Pen pen = new Pen(Color.Black, PEN_THICKNESS);

            paper.DrawRectangle(pen, left - PEN_THICKNESS, top - PEN_THICKNESS, (Dice.DICE_SIZE + PEN_THICKNESS) * ROWS + PEN_THICKNESS, (Dice.DICE_SIZE + PEN_THICKNESS) * COLUMNS + PEN_THICKNESS);

            for (int a = 0; a < ROWS; a++)
                for (int b = 0; b < COLUMNS; b++)
                    tileArray[a, b].Draw(paper, left + (Dice.DICE_SIZE + BoardPiece.PEN_THICKNESS) * a, top + (Dice.DICE_SIZE + BoardPiece.PEN_THICKNESS) * b);
        }
    }
}
