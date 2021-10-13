using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada
{
    public abstract class InteractiveBoardPiece : BoardPiece
    {
        public abstract bool IsMouseOn(int x, int y);
    }
}
