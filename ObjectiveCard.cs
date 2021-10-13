using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sagrada
{
    public abstract class ObjectiveCard : BoardPiece
    {
        public abstract int Score(Tile[,] tileArray);
    }
}
