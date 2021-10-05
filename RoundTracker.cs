﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada
{
    class RoundTracker : BoardPiece
    {
        //Dice[] 

        public RoundTracker(int x, int y)
        {
            left = x;
            top = y;
        }

        public override void Draw(Graphics paper)
        {
            Pen pen = new Pen(Color.Black, PEN_THICKNESS);
            SolidBrush br = new SolidBrush(Color.Black);

            paper.DrawRectangle(pen, left - PEN_THICKNESS, top - PEN_THICKNESS, (DICE_SIZE + PEN_THICKNESS) * ROUNDS + PEN_THICKNESS, (DICE_SIZE + PEN_THICKNESS) + PEN_THICKNESS);
        }
    }
}