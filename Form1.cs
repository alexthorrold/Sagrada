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
        WindowPattern w;
        //RoundTracker r;
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
            this.Invalidate();

            w = gamePieces.GetWindow();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            w.Draw(e.Graphics);
            //r.Draw(e.Graphics);

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
        }
    }
}
