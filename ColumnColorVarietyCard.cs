using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada
{
    public class ColumnColorVarietyCard : PublicCard
    {
        public ColumnColorVarietyCard(int x, int y)
        {
            value = 5;
            left = x;
            top = y;
        }

        public override void Draw(Graphics paper)
        {
            Image img = Image.FromFile(@"..\..\Resources\column-color-variety.jpg");

            paper.DrawImage(img, left, top, 105, 150);
        }

        public override int Score(Tile[,] tileArray)
        {
            List<Color> usedColors;
            int count = 0;

            for (int a = 0; a < WindowPattern.ROWS; a++)
            {
                usedColors = new List<Color>();

                for (int b = 0; b < WindowPattern.COLUMNS; b++)
                {
                    if (tileArray[a, b].Dice != null)
                    {
                        //Break if there is already a dice of the same color in current column
                        if (usedColors.Contains(tileArray[a, b].Dice.Color))
                            break;
                    }
                    //If there is no dice, there can not be a full column of non-repeating colors, break and go to next column
                    else
                    {
                        break;
                    }

                    //If all column have been checked and are different colors (as the for loop never broke), add one to score
                    if (b == WindowPattern.COLUMNS - 1)
                        count++;
                }
            }

            return value * count;
        }
    }
}
