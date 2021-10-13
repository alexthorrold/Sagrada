using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sagrada
{
    public class FluxBrushToolCard : ToolCard
    {
        public FluxBrushToolCard(int x, int y)
        {
            left = x;
            top = y;
        }

        public override void Draw(Graphics paper)
        {
            Image img = Image.FromFile(@"..\..\Resources\eglomise-brush.jpg");
            Pen pen = new Pen(Color.Red, 7);

            if (selected)
                paper.DrawRectangle(pen, left, top, 105, 150);

            paper.DrawImage(img, left, top, 105, 150);
        }
    }
}
