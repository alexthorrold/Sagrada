using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada
{
    class RoundTracker : BoardPiece
    {
        public const int ROUNDS = 10;

        private List<Dice>[] diceArray;
        private int[] diceIndex;

        private Dice unplayedRoundDice;

        public RoundTracker(int x, int y)
        {
            left = x;
            top = y;

            diceArray = new List<Dice>[ROUNDS];

            for (int i = 0; i < ROUNDS; i++)
                diceArray[i] = new List<Dice>();

            diceIndex = new int[ROUNDS];
            unplayedRoundDice = new Dice(Color.White, 0);
        }

        public List<Dice>[] DiceArray
        {
            get { return diceArray; }
        }

        public int Total
        {
            get
            {
                int total = 0;

                foreach (List<Dice> ld in diceArray)
                    foreach (Dice d in ld)
                        total += d.Number;

                return total;
            }
        }

        public void AddDice(int round, Dice d)
        {
            diceArray[round].Add(d);
        }

        public bool IsMouseOn(int x, int y)
        {
            return x >= left && x <= left + Dice.DICE_SIZE * ROUNDS + PEN_THICKNESS * (ROUNDS - 1) && y >= top && y <= top + Dice.DICE_SIZE;
        }

        public void Index(int x, int y)
        {
            int round = (x - left) / (Dice.DICE_SIZE + PEN_THICKNESS);
            
            if (diceArray[round].Count > 1)
                diceIndex[round] = (diceIndex[round] + 1) % diceArray[round].Count;
        }

        public override void Draw(Graphics paper)
        {
            Pen pen = new Pen(Color.Black, PEN_THICKNESS);

            paper.DrawRectangle(pen, left - PEN_THICKNESS, top - PEN_THICKNESS, (Dice.DICE_SIZE + PEN_THICKNESS) * ROUNDS + PEN_THICKNESS, (Dice.DICE_SIZE + PEN_THICKNESS) + PEN_THICKNESS);

            for (int i = 0; i < ROUNDS; i++)
            {
                if (diceArray[i].Count > 0)
                    diceArray[i][diceIndex[i]].Draw(paper, left + (Dice.DICE_SIZE + PEN_THICKNESS) * i, top);
                else
                    unplayedRoundDice.Draw(paper, left + (Dice.DICE_SIZE + PEN_THICKNESS) * i, top);
            }
        }
    }
}
