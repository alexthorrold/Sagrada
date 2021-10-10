using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sagrada
{
    public class Dice
    {
        public const int DICE_SIZE = 45;
        public const int DOT_SIZE = 11;

        private Color color;
        private int number;

        public Dice(Color c, int i)
        {
            color = c;
            number = i;
        }

        public Dice(Color c, int i, int x, int y)
        {
            color = c;
            number = i;
        }

        public Color Color
        {
            get { return color; }
        }

        public int Number
        {
            get { return number; }
        }

        public bool PlacementCheck(Dice d)
        {
            if (color == d.Color || number == d.Number)
                return false;
            return true;
        }

        public void Flip()
        {
            if (number == 1)
                number = 6;
            else if (number == 2)
                number = 5;
            else if (number == 3)
                number = 4;
            else if (number == 4)
                number = 3;
            else if (number == 5)
                number = 2;
            else
                number = 1;
        }

        public void Draw(Graphics paper, int x, int y)
        {
            Pen pen = new Pen(Color.Black, BoardPiece.PEN_THICKNESS);
            SolidBrush br = new SolidBrush(Color);

            paper.DrawRectangle(pen, x, y, DICE_SIZE, DICE_SIZE);
            paper.FillRectangle(br, x, y, DICE_SIZE, DICE_SIZE);

            DrawDots(paper, x, y);
        }

        public void Draw(Graphics paper, int x, int y, Color c)
        {
            Pen pen = new Pen(c, BoardPiece.PEN_THICKNESS);
            SolidBrush br = new SolidBrush(Color);

            paper.DrawRectangle(pen, x, y, DICE_SIZE, DICE_SIZE);
            paper.FillRectangle(br, x, y, DICE_SIZE, DICE_SIZE);

            DrawDots(paper, x, y);
        }

        private void DrawDots(Graphics paper, int x, int y)
        {
            SolidBrush br = new SolidBrush(Color.Black);

            if (number == 1 || number == 3 || number == 5)
            {
                paper.FillEllipse(br, x + (float)16.75, y + (float)16.75, DOT_SIZE, DOT_SIZE);
            }
            if (number > 1)
            {
                paper.FillEllipse(br, x, y, DOT_SIZE, DOT_SIZE);
                paper.FillEllipse(br, x + 33, y + 33, DOT_SIZE, DOT_SIZE);
            }
            if (number > 3)
            {
                paper.FillEllipse(br, x + 33, y, DOT_SIZE, DOT_SIZE);
                paper.FillEllipse(br, x, y + 33, DOT_SIZE, DOT_SIZE);
            }
            if (number == 6)
            {
                paper.FillEllipse(br, x, y + (float)16.75, DOT_SIZE, DOT_SIZE);
                paper.FillEllipse(br, x + 33, y + (float)16.75, DOT_SIZE, DOT_SIZE);
            }
        }
    }
}
