using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada
{
    public class ColorVarietyCard : PublicCard
    {
        public ColorVarietyCard(int x, int y)
        {
            value = 4;
            left = x;
            top = y;
        }

        public override void Draw(Graphics paper)
        {
            Image img = Image.FromFile(@"..\..\Resources\color-variety.jpg");

            paper.DrawImage(img, left, top, CARD_WIDTH, CARD_HEIGHT);
        }

        public override int Score(Tile[,] tileArray)
        {
            int red = 0;
            int yellow = 0;
            int blue = 0;
            int green = 0;
            int purple = 0;

            foreach (Tile t in tileArray)
            {
                if (t.Dice != null)
                {
                    if (t.Dice.Color == Color.Red)
                        red++;
                    else if (t.Dice.Color == Color.Yellow)
                        yellow++;
                    else if (t.Dice.Color == Color.Blue)
                        blue++;
                    else if (t.Dice.Color == Color.Green)
                        green++;
                    else
                        purple++;
                }
            }

            //Gets the least appearing color, which is the amount of sets of each color
            int sets = red;

            if (yellow < sets)
                sets = yellow;
            if (blue < sets)
                sets = blue;
            if (green < sets)
                sets = green;
            if (purple < sets)
                sets = purple;

            return sets * value;
        }
    }
}
