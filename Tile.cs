using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sagrada
{
    public class Tile
    {
        private Dice dice;
        private Color color;
        private int number;

        public Tile()
        {
            color = Color.White;
            number = 0;
        }

        public Tile(Color c)
        {
            color = c;
            number = 0;
        }

        public Tile(int i)
        {
            color = Color.Gray;
            number = i;
        }

        public Dice Dice
        {
            get { return dice; }
            set
            {
                if (dice == null)
                {
                    color = value.Color;
                    number = value.Number;
                    dice = value;
                }
                else
                {
                    throw new Exception("Tile already contains a dice.");
                }
            }
        }

        public Color Color
        {
            get { return color; }
        }

        public int Number
        {
            get { return number; }
        }

        public void Draw(Graphics paper, int x, int y)
        {
            if (dice != null)
            {
                dice.Draw(paper, x, y);
            }
            else
            {
                Pen pen = new Pen(Color.Black, BoardPiece.PEN_THICKNESS);
                SolidBrush br = new SolidBrush(Color);

                paper.DrawRectangle(pen, x, y, Dice.DICE_SIZE, Dice.DICE_SIZE);
                paper.FillRectangle(br, x, y, Dice.DICE_SIZE, Dice.DICE_SIZE);

                br.Color = Color.Black;

                if (number == 1 || number == 3 || number == 5)
                {
                    paper.FillEllipse(br, x + (float)16.75, y + (float)16.75, Dice.DOT_SIZE, Dice.DOT_SIZE);
                }
                if (number > 1)
                {
                    paper.FillEllipse(br, x, y, Dice.DOT_SIZE, Dice.DOT_SIZE);
                    paper.FillEllipse(br, x + 33, y + 33, Dice.DOT_SIZE, Dice.DOT_SIZE);
                }
                if (number > 3)
                {
                    paper.FillEllipse(br, x + 33, y, Dice.DOT_SIZE, Dice.DOT_SIZE);
                    paper.FillEllipse(br, x, y + 33, Dice.DOT_SIZE, Dice.DOT_SIZE);
                }
                if (number == 6)
                {
                    paper.FillEllipse(br, x, y + (float)16.75, Dice.DOT_SIZE, Dice.DOT_SIZE);
                    paper.FillEllipse(br, x + 33, y + (float)16.75, Dice.DOT_SIZE, Dice.DOT_SIZE);
                }
            }
        }

        public bool PlacementCheck(Dice d)
        {
            return !(d.Color == color || d.Number == number);
        }
    }
}
