using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sagrada
{
    public partial class Form1 : Form
    {
        GamePieces gamePieces = new GamePieces();
        //WindowPattern w = new WindowPattern(50, 50);
        Dice current1;
        Dice current2;
        Dice current3;
        Dice current4;
        Dice selected;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int a = 0; a < 5; a++)
            {
                for (int b = 0; b < 4; b += 2)
                {
                    w.DiceArray[a, b] = gamePieces.GetDice();
                    w.DiceArray[a, b].MoveTo(a * 99 + 50, b * 99 + 50);
                }
            }

            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //w.IsMouseOn(410, 397);
            w.Draw(e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            w.IsMouseOn(e.X, e.Y);

            //foreach (BoardPiece b in boardPieceList)
            //{
            //    if (b.IsMouseOn(e.X, e.Y))
            //    {

            //    }
            //}
        }
    }
}
