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
        List<Dice>[] diceArray = new List<Dice>[ROUNDS];
        int[] diceIndex = new int[ROUNDS];

        public RoundTracker(int x, int y)
        {
            left = x;
            top = y;
        }

        public void AddDice(int round, Dice d)
        {
            diceArray[round].Add(d);
        }

        public override void Draw(Graphics paper)
        {
            Pen pen = new Pen(Color.Black, PEN_THICKNESS);

            paper.DrawRectangle(pen, left - PEN_THICKNESS, top - PEN_THICKNESS, (DICE_SIZE + PEN_THICKNESS) * ROUNDS + PEN_THICKNESS, (DICE_SIZE + PEN_THICKNESS) + PEN_THICKNESS);

            Dice currentDice;

            int x = left;

            //for ()

            //foreach (List<Dice> ld in diceArray)
            //{
            //    ld[diceIndex[]]
            //}

            //for (int a = 0; a < ROWS; a++)
            //{
            //    drawY = top;

            //    for (int b = 0; b < COLUMNS; b++)
            //    {
            //        if (DiceArray[a, b] != null)
            //        {
            //            currentDice = DiceArray[a, b];
            //        }
            //        else if (requirementArray[a, b] != null)
            //        {
            //            currentDice = requirementArray[a, b];
            //            currentDice.MoveTo(a * (DICE_SIZE + PEN_THICKNESS) + left, b * (DICE_SIZE + PEN_THICKNESS) + top);
            //        }
            //        else
            //        {
            //            currentDice = new Dice(Color.LightGray, 0, a * (DICE_SIZE + PEN_THICKNESS) + left, b * (DICE_SIZE + PEN_THICKNESS) + top);
            //        }

            //        currentDice.Draw(paper);

            //        drawY += DICE_SIZE + PEN_THICKNESS;
            //    }
            //    drawX += DICE_SIZE + PEN_THICKNESS;
        }
    }
}
