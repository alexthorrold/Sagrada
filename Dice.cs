using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sagrada
{
    public class Dice : BoardPiece
    {
        private const int DOT_SIZE = 22;
        
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

            MoveTo(x, y);
        }

        public Color Color
        {
            get { return color; }
        }

        public int Number
        {
            get { return number; }
        }

        public override bool IsMouseOn(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void MoveTo(int x, int y)
        {
            left = x;
            top = y;
        }

        public override void Draw(Graphics paper)
        {
            Pen pen = new Pen(Color.Black, PEN_THICKNESS);
            SolidBrush br = new SolidBrush(Color);

            paper.DrawRectangle(pen, left, top, DICE_SIZE, DICE_SIZE);
            paper.FillRectangle(br, left, top, DICE_SIZE, DICE_SIZE);

            br.Color = Color.Black;

            if (number == 1 || number == 3 || number == 5)
            {
                paper.FillEllipse(br, left + (float)33.5, top + (float)33.5, 22, 22);
            }
            if (number > 1)
            {
                paper.FillEllipse(br, left, top, DOT_SIZE, DOT_SIZE);
                paper.FillEllipse(br, left + 67, top + 67, DOT_SIZE, DOT_SIZE);
            }
            if (number > 3)
            {
                paper.FillEllipse(br, left + 67, top, DOT_SIZE, DOT_SIZE);
                paper.FillEllipse(br, left, top + 67, DOT_SIZE, DOT_SIZE);
            }
            if (number == 6)
            {
                paper.FillEllipse(br, left, top + (float)33.5, DOT_SIZE, DOT_SIZE);
                paper.FillEllipse(br, left + 67, top + (float)33.5, DOT_SIZE, DOT_SIZE);
            }
        }
    }
}
