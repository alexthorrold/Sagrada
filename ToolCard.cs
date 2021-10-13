using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada
{
    public abstract class ToolCard : InteractiveBoardPiece
    {
        protected bool used = false;

        public bool Used
        {
            get { return used; }
            set { used = value; }
        }

        public override bool IsMouseOn(int x, int y)
        {
            if (x >= left && x <= left + CARD_WIDTH && y >= top && y <= top + CARD_HEIGHT)
                return true;
            return false;
        }
    }
}
