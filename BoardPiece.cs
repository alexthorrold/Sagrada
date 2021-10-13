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
        public const int PEN_THICKNESS = 5;
        public const int CARD_WIDTH = 105;
        public const int CARD_HEIGHT = 150;

        protected int left;
        protected int top;

        public int Left
        {
            get { return left; }
            set { left = value; }
        }

        public int Top
        {
            get { return top; }
            set { top = value; }
        }

        public abstract void Draw(Graphics paper);
    }
}
