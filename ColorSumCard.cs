using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sagrada
{
    public class ColorSumCard : BoardPiece
    {
        private Color color;

        public ColorSumCard(Color c, int x, int y)
        {
            if (c == Color.Yellow || c == Color.Red || c == Color.Green || c == Color.Blue || c == Color.Purple)
                color = c;
            else
                throw new Exception("Invalid color provided.");

            left = x;
            top = y;
        }

        public override void Draw(Graphics paper)
        {
            Image img;

            if (color == Color.Yellow)
                img = Image.FromFile(@"..\..\Resources\priv-yellow.png");
            else if (color == Color.Red)
                img = Image.FromFile(@"..\..\Resources\priv-red.png");
            else if (color == Color.Blue)
                img = Image.FromFile(@"..\..\Resources\priv-blue.png");
            else if (color == Color.Green)
                img = Image.FromFile(@"..\..\Resources\priv-green.png");
            else
                img = Image.FromFile(@"..\..\Resources\priv-purple.png");

            paper.DrawImage(img, left, top, 100, 100);
        }

        public int Score(Tile[,] tileArray)
        {
            int score = 0;

            foreach (Tile t in tileArray)
                if (t.Dice != null)
                    if (t.Dice.Color == color)
                        score += t.Dice.Number;

            return score;
        }
    }
}
