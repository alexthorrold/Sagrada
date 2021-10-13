using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada
{
    public class ColumnShadeVarietyCard : PublicCard
    {
        public ColumnShadeVarietyCard(int x, int y)
        {
            value = 4;
            left = x;
            top = y;
        }

        public override void Draw(Graphics paper)
        {
            Image img = Image.FromFile(@"..\..\Resources\column-shade-variety.jpg");

            paper.DrawImage(img, left, top, CARD_WIDTH, CARD_HEIGHT);
        }

        public override int Score(Tile[,] tileArray)
        {
            List<int> usedNumbers;
            int count = 0;

            for (int a = 0; a < WindowPattern.ROWS; a++)
            {
                usedNumbers = new List<int>();

                for (int b = 0; b < WindowPattern.COLUMNS; b++)
                {
                    if (tileArray[a, b].Dice != null)
                    {
                        //Break if there is already a dice of the same number in current column
                        if (usedNumbers.Contains(tileArray[a, b].Dice.Number))
                            break;
                    }
                    //If there is no dice, there can not be a full column of non-repeating number, break and go to next column
                    else
                    {
                        break;
                    }

                    //If all column have been checked and are different number (as the for loop never broke), add one to score
                    if (b == WindowPattern.COLUMNS - 1)
                        count++;
                }
            }

            return value * count;
        }
    }
}
