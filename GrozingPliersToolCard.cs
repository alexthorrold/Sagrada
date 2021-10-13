using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada
{
    public class GrozingPliersToolCard : DraftToolCard
    {
        public GrozingPliersToolCard(int x, int y)
        {
            left = x;
            top = y;
        }

        public override void Draw(Graphics paper)
        {
            Image img = Image.FromFile(@"..\..\Resources\eglomise-brush.jpg");

            paper.DrawImage(img, left, top, 105, 150);
        }

        //public WindowPattern (WindowPattern w)
        //{

        //}
    }
}
