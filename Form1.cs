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
        RoundTracker r = new RoundTracker(450, 50);
        CurrentDice c = new CurrentDice(500, 200);
        Dice selected = new Dice(Color.Red, 4);

        bool gameStarted = false;
        int roundIndex = 0;
        int currentRoundTurn = 0;
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

            w = new WindowPattern(gamePieces.GetNextRequirements(), 50, 50);

            c.SetDice(gamePieces.GetDice(), gamePieces.GetDice(), gamePieces.GetDice(), gamePieces.GetDice());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            w.Draw(e.Graphics);
            r.Draw(e.Graphics);
            c.Draw(e.Graphics);

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
            if (gameStarted)
            {
                if (w.IsMouseOn(e.X, e.Y))
                {
                    if (selected != null)
                    {
                        int row = w.GetRow(e.X);
                        int column = w.GetColumn(e.Y);

                        if (w.PlacementCheck(selected, row, column))
                        {
                            w.AddDice(selected, row, column);
                            c.RemoveSelected();
                            selected = null;
                            currentRoundTurn++;
                        }
                        else
                            MessageBox.Show("Invalid placement.");
                    }
                    else
                    {
                        MessageBox.Show("Working");
                    }
                }
                else if (c.IsMouseOn(e.X, e.Y))
                {
                    if (currentRoundTurn < 2)
                    {
                        c.SetSelected(e.X, e.Y);

                        if (c.Selected.Color != Color.White)
                            selected = c.Selected;
                        else
                            c.ResetSelected();
                    }
                    else
                    {
                        MessageBox.Show("Maximum placements for this round reached.");
                    }
                }
                else if (r.IsMouseOn(e.X, e.Y))
                {
                    r.Index(e.X, e.Y);
                }
                else
                {
                    selected = null;
                    c.ResetSelected();
                }

                this.Invalidate();
            }
            else
            {
                MessageBox.Show("Please select a board and proceed.");
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            w = new WindowPattern(gamePieces.GetPreviousRequirements(), 50, 50);
            this.Invalidate();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            w = new WindowPattern(gamePieces.GetNextRequirements(), 50, 50);
            this.Invalidate();
        }

        private void buttonProceed_Click(object sender, EventArgs e)
        {
            buttonPrevious.Hide();
            buttonNext.Hide();
            buttonProceed.Hide();
            buttonNextRound.Show();

            gameStarted = true;
        }

        private void buttonNextRound_Click(object sender, EventArgs e)
        {
            foreach (Dice d in c.DiceArray)
                if (d.Color != Color.White)
                    r.AddDice(roundIndex, d);

            roundIndex++;
            currentRoundTurn = 0;

            this.Invalidate();

            if (roundIndex == 10)
            {
                buttonNextRound.Hide();
                c.Clear();
                MessageBox.Show(r.Total.ToString());
            }
            else
                c.SetDice(gamePieces.GetDice(), gamePieces.GetDice(), gamePieces.GetDice(), gamePieces.GetDice());
        }
    }
}
