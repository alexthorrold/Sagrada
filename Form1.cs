﻿using System;
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
        //Dice[] currentDiceArray = new Dice[4];
        CurrentDice c = new CurrentDice(500, 200);
        Dice selected = new Dice(Color.Red, 4);
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

            w = new WindowPattern(gamePieces.GetRequirements(), 50, 50);

            c.SetDice(gamePieces.GetDice(), gamePieces.GetDice(), gamePieces.GetDice(), gamePieces.GetDice());

            //currentDiceArray[0] = gamePieces.GetDice();
            //currentDiceArray[1] = gamePieces.GetDice();
            //currentDiceArray[2] = gamePieces.GetDice();
            //currentDiceArray[3] = gamePieces.GetDice();

            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            w.Draw(e.Graphics);
            //r.Draw(e.Graphics);
            c.Draw(e.Graphics);

            //foreach (Dice d in currentDiceArray)
            //{
            //    d.Draw(e.Graphics);
            //}

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
            //if (c.HasSelected())
            //    w.ClickCheck(c.SendToWindow(), e.X, e.Y);

            //r.ClickCheck(e.X, e.Y);
            //c.ClickCheck(e.X, e.Y);

            //w.AddTile(selected, 3, 3);

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
                c.SetSelected(e.X, e.Y);

                if (c.Selected.Color != Color.White)
                    selected = c.Selected;
                else
                    c.ResetSelected();
            }
            else
            {
                selected = null;
                c.ResetSelected();
            }
            
            this.Invalidate();
        }
    }
}
