using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sagrada
{
    public abstract class BoardPiece
    {
        protected const int DICE_SIZE = 90;
        protected const int PEN_THICKNESS = 9;

        protected int left;
        protected int top;

        public abstract bool IsMouseOn(int x, int y);

        public abstract void Draw(Graphics paper);
    }
}
