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

        DrawDots[] drawDotsFunc;

        public Dice(Color c, int i)
        {
            color = c;
            number = i;

            drawDotsFunc = new DrawDots[] { drawOneDot, drawTwoDots, drawThreeDots, drawFourDots, drawFiveDots, drawSixDots };
        }

        public Color Color
        {
            get { return color; }
        }

        public int Number
        {
            get { return number; }
        }

        //public void Flip()
        //{
        //    if (number == 1)
        //        number = 6;
        //    else if (number == 2)
        //        number = 5;
        //    else if (number == 3)
        //        number = 4;
        //    else if (number == 4)
        //        number = 3;
        //    else if (number == 5)
        //        number = 2;
        //    else
        //        number = 1;
        //}

        public void Draw(Graphics paper, int x, int y)
        {
            Pen pen = new Pen(Color.Black, BoardPiece.PEN_THICKNESS);
            SolidBrush br = new SolidBrush(Color);

            paper.DrawRectangle(pen, x, y, DICE_SIZE, DICE_SIZE);
            paper.FillRectangle(br, x, y, DICE_SIZE, DICE_SIZE);

            br.Color = Color.Black;

            //FIX TILES TOO
            if (number != 0)
            {
                DrawDots drawDots = drawDotsFunc[Number - 1];
                drawDots(paper, br, x, y);
            }
        }

        public void Draw(Graphics paper, int x, int y, Color c)
        {
            Pen pen = new Pen(c, BoardPiece.PEN_THICKNESS);
            SolidBrush br = new SolidBrush(Color);

            paper.DrawRectangle(pen, x, y, DICE_SIZE, DICE_SIZE);
            paper.FillRectangle(br, x, y, DICE_SIZE, DICE_SIZE);

            br.Color = Color.Black;

            if (number != 0)
            {
                DrawDots drawDots = drawDotsFunc[Number - 1];
                drawDots(paper, br, x, y);
            }
        }

        //Delegate code credited to Professor Shaoqun Wu
        private delegate void DrawDots(Graphics paper, Brush br, int x, int y);

        DrawDots drawOneDot = (g, br, x, y) =>
        {
            g.FillEllipse(br, x + (float)16.75, y + (float)16.75, DOT_SIZE, DOT_SIZE);
        };

        DrawDots drawTwoDots = (g, br, x, y) =>
        {
            g.FillEllipse(br, x, y, DOT_SIZE, DOT_SIZE);
            g.FillEllipse(br, x + 33, y + 33, DOT_SIZE, DOT_SIZE);
        };

        DrawDots drawThreeDots = (g, br, x, y) =>
        {
            g.FillEllipse(br, x + (float)16.75, y + (float)16.75, DOT_SIZE, DOT_SIZE);
            g.FillEllipse(br, x, y, DOT_SIZE, DOT_SIZE);
            g.FillEllipse(br, x + 33, y + 33, DOT_SIZE, DOT_SIZE);
        };

        DrawDots drawFourDots = (g, br, x, y) =>
        {
            g.FillEllipse(br, x, y, DOT_SIZE, DOT_SIZE);
            g.FillEllipse(br, x + 33, y + 33, DOT_SIZE, DOT_SIZE);
            g.FillEllipse(br, x + 33, y, DOT_SIZE, DOT_SIZE);
            g.FillEllipse(br, x, y + 33, DOT_SIZE, DOT_SIZE);
        };

        DrawDots drawFiveDots = (g, br, x, y) =>
        {
            g.FillEllipse(br, x + (float)16.75, y + (float)16.75, DOT_SIZE, DOT_SIZE);
            g.FillEllipse(br, x, y, DOT_SIZE, DOT_SIZE);
            g.FillEllipse(br, x + 33, y + 33, DOT_SIZE, DOT_SIZE);
            g.FillEllipse(br, x + 33, y, DOT_SIZE, DOT_SIZE);
            g.FillEllipse(br, x, y + 33, DOT_SIZE, DOT_SIZE);
        };

        DrawDots drawSixDots = (g, br, x, y) =>
        {
            g.FillEllipse(br, x, y, DOT_SIZE, DOT_SIZE);
            g.FillEllipse(br, x + 33, y + 33, DOT_SIZE, DOT_SIZE);
            g.FillEllipse(br, x + 33, y, DOT_SIZE, DOT_SIZE);
            g.FillEllipse(br, x, y + 33, DOT_SIZE, DOT_SIZE);
            g.FillEllipse(br, x, y + (float)16.75, DOT_SIZE, DOT_SIZE);
            g.FillEllipse(br, x + 33, y + (float)16.75, DOT_SIZE, DOT_SIZE);
        };
    }
}
