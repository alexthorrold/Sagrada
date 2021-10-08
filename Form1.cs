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
        RoundTracker r = new RoundTracker(50, 50);
        Dice[] currentDiceArray = new Dice[4];
        Dice selected;
        //Objective priv1
        //Objective priv2
        //Objective pub1
        //Objective pub2
        //ToolCard tool1
        //ToolCard tool2
        //ToolCard tool3

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Invalidate();

            w = gamePieces.GetWindow(300, 300);

            //currentDiceArray[0] = gamePieces.GetDice();
            //currentDiceArray[1] = gamePieces.GetDice();
            //currentDiceArray[2] = gamePieces.GetDice();
            //currentDiceArray[3] = gamePieces.GetDice();

            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            w.Draw(e.Graphics);
            r.Draw(e.Graphics);

            foreach (Dice d in currentDiceArray)
            {
                d.Draw(e.Graphics);
            }

            //current1.Draw(e.Graphics);
            //current2.Draw(e.Graphics);
            //current3.Draw(e.Graphics);
            //current4.Draw(e.Graphics);
            //priv1.Draw(e.Graphics);
            //priv2.Draw(e.Graphics);
            //pub1.Draw(e.Graphics);
            //pub2.Draw(e.Graphics);
            //tool1.Draw(e.Graphics);
            //tool2.Draw(e.Graphics);
            //tool3.Draw(e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            w.ClickCheck(e.X, e.Y);
            r.ClickCheck(e.X, e.Y);

            foreach (Dice )

            this.Invalidate();
        }
    }
}
