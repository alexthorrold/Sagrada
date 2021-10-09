using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada
{
    class CurrentDice : BoardPiece
    {
        private const int DICE_PER_ROUND = 4;

        private Dice[] diceArray;
        private int selectedIndex = -1;

        public CurrentDice(int x, int y)
        {
            left = x;
            top = y;

            diceArray = new Dice[DICE_PER_ROUND];
        }

        public bool HasSelected()
        {
            if (selectedIndex != -1)
                return true;
            return false;
        }

        public void SetDice(Dice d1, Dice d2, Dice d3, Dice d4)
        {
            d1.MoveTo(left, top);
            d2.MoveTo(left + DICE_SIZE + PEN_THICKNESS, top);
            d3.MoveTo(left + (DICE_SIZE + PEN_THICKNESS) * 2, top);
            d4.MoveTo(left + (DICE_SIZE + PEN_THICKNESS) * 3, top);

            diceArray[0] = d1;
            diceArray[1] = d2;
            diceArray[2] = d3;
            diceArray[3] = d4;
        }

        public void ClickCheck(int x, int y)
        {
            if (x >= left && x <= left + DICE_SIZE * DICE_PER_ROUND + PEN_THICKNESS * (DICE_PER_ROUND - 1) && y >= top && y <= top + DICE_SIZE)
            {
                selectedIndex = (x - left) / (DICE_SIZE + PEN_THICKNESS);
            }
        }

        public Dice SendToWindow()
        {
            Dice selected = diceArray[selectedIndex];

            diceArray[selectedIndex] = new Dice(Color.White, 0, left + (DICE_SIZE + PEN_THICKNESS) * selectedIndex, top);

            return selected;
        }

        public override void Draw(Graphics paper)
        {
            Pen pen = new Pen(Color.Black, PEN_THICKNESS);

            paper.DrawRectangle(pen, left - PEN_THICKNESS, top - PEN_THICKNESS, (DICE_SIZE + PEN_THICKNESS) * DICE_PER_ROUND + PEN_THICKNESS, (DICE_SIZE + PEN_THICKNESS) + PEN_THICKNESS);

            foreach (Dice d in diceArray)
            {
                d.Draw(paper);
            }
        }
    }
}
