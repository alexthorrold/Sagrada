using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada
{
    public class RowShadeVarietyCard : PublicCard
    {
        public RowShadeVarietyCard(int x, int y)
        {
            value = 5;
            left = x;
            top = y;
        }

        public override void Draw(Graphics paper)
        {
            Image img = Image.FromFile(@"..\..\Resources\row-shade-variety.jpg");

            paper.DrawImage(img, left, top, 105, 150);
        }

        public override int Score(Tile[,] tileArray)
        {
            List<int> usedNumbers;
            int count = 0;

            for (int a = 0; a < WindowPattern.COLUMNS; a++)
            {
                usedNumbers = new List<int>();

                for (int b = 0; b < WindowPattern.ROWS; b++)
                {
                    if (tileArray[b, a].Dice != null)
                    {
                        //Break if there is already a dice of the same number in current column
                        if (usedNumbers.Contains(tileArray[b, a].Dice.Number))
                            break;
                    }
                    //If there is no dice, there can not be a full column of non-repeating number, break and go to next column
                    else
                    {
                        break;
                    }

                    //If all column have been checked and are different number (as the for loop never broke), add one to score
                    if (b == WindowPattern.ROWS - 1)
                        count++;
                }
            }

            return value * count;
        }
    }
}
