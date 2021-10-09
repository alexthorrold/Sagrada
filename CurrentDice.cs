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

        public Dice[] DiceArray
        {
            get { return diceArray; }
        }

        public Dice Selected
        {
            get { return diceArray[selectedIndex]; }
        }

        public bool IsMouseOn(int x, int y)
        {
            if (x >= left && x <= left + Dice.DICE_SIZE * DICE_PER_ROUND + PEN_THICKNESS * (DICE_PER_ROUND - 1) && y >= top && y <= top + Dice.DICE_SIZE)
                return true;
            return false;
        }

        public void SetSelected(int x, int y)
        {
            selectedIndex = (x - left) / (Dice.DICE_SIZE + PEN_THICKNESS);
        }

        public void ResetSelected()
        {
            selectedIndex = -1;
        }

        public void RemoveSelected()
        {
            diceArray[selectedIndex] = new Dice(Color.White, 0);
            ResetSelected();
        }

        public void Clear()
        {
            for (int i = 0; i < DICE_PER_ROUND; i++)
            {
                diceArray[i] = new Dice(Color.White, 0);
            }
        }

        public void SetDice(Dice d1, Dice d2, Dice d3, Dice d4)
        {
            diceArray[0] = d1;
            diceArray[1] = d2;
            diceArray[2] = d3;
            diceArray[3] = d4;
        }

        public override void Draw(Graphics paper)
        {
            Pen pen = new Pen(Color.Black, PEN_THICKNESS);

            paper.DrawRectangle(pen, left - PEN_THICKNESS, top - PEN_THICKNESS, (Dice.DICE_SIZE + PEN_THICKNESS) * DICE_PER_ROUND + PEN_THICKNESS, (Dice.DICE_SIZE + PEN_THICKNESS) + PEN_THICKNESS);

            for (int i = 0; i < DICE_PER_ROUND; i++)
                diceArray[i].Draw(paper, left + (Dice.DICE_SIZE + PEN_THICKNESS) * i, top);

            if (selectedIndex != -1)
                diceArray[selectedIndex].Draw(paper, left + (Dice.DICE_SIZE + PEN_THICKNESS) * selectedIndex, top, Color.Gray);
        }
    }
}
