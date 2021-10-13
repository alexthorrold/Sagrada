using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada
{
    public abstract class ObjectiveCard : BoardPiece
    {
        abstract public bool IsMouseOn();

        abstract public void Draw();
    }
}
