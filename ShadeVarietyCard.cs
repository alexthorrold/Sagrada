using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada
{
    public class ShadeVarietyCard : PublicCard
    {
        public ShadeVarietyCard(int x, int y)
        {
            value = 5;
            left = x;
            top = y;
        }

        public override void Draw(Graphics paper)
        {
            Image img = Image.FromFile(@"..\..\Resources\shade-variety.jpg");

            paper.DrawImage(img, left, top, CARD_WIDTH, CARD_HEIGHT);
        }

        public override int Score(Tile[,] tileArray)
        {
            int[] index = new int[6];

            foreach (Tile t in tileArray)
            {
                if (t.Dice != null)
                {
                    index[t.Dice.Number - 1]++;
                }
            }

            //Gets the least occuring number, which is the number of sets of each number
            int sets = index[0];

            foreach (int i in index)
                if (i < sets)
                    sets = i;

            return value * sets;
        }
    }
}
