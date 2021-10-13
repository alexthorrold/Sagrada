using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada
{
    public class RowColorVarietyCard : PublicCard
    {
        public RowColorVarietyCard(int x, int y)
        {
            value = 6;
            left = x;
            top = y;
        }

        public override void Draw(Graphics paper)
        {
            Image img = Image.FromFile(@"..\..\Resources\row-color-variety.jpg");

            paper.DrawImage(img, left, top, 105, 150);
        }

        public override int Score(Tile[,] tileArray)
        {
            List<Color> usedColors;
            int count = 0;

            for (int a = 0; a < WindowPattern.COLUMNS; a++)
            {
                usedColors = new List<Color>();

                for (int b = 0; b < WindowPattern.ROWS; b++)
                {
                    if (tileArray[b, a].Dice != null)
                    {
                        //Break if there is already a dice of the same color in current row
                        if (usedColors.Contains(tileArray[b, a].Dice.Color))
                            break;
                    }
                    //If there is no dice, there can not be a full row of non-repeating colors, break and go to next column
                    else
                    {
                        break;
                    }

                    //If all rows have been checked and are different colors (as the for loop never broke), add one to score
                    if (b == WindowPattern.ROWS - 1)
                        count++;
                }
            }

            return value * count;
        }
    }
}
