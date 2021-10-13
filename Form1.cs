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
        WindowPattern windowPattern;
        RoundTracker roundTracker = new RoundTracker(450, 50);
        DraftPool draftPool = new DraftPool(500, 200);
        Dice selectedDie = new Dice(Color.Red, 4);
        ToolCard selectedToolCard;
        //Holds the objectives the player will gain score for,
        //First two spots are private objectives, last two spots are public objectives
        ObjectiveCard[] objectiveArray = new ObjectiveCard[4];
        ToolCard[] toolCardArray = new ToolCard[3] { new GrozingPliersToolCard(10, 300), null, null };

        bool gameStarted = false;
        int roundIndex = 0;
        int currentRoundTurn = 1;
        int toolUsedTurn = 0;
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

            windowPattern = new WindowPattern(gamePieces.GetNextRequirements(), 50, 50);
            draftPool.SetDice(gamePieces.GetDice(), gamePieces.GetDice(), gamePieces.GetDice(), gamePieces.GetDice());
            objectiveArray[0] = gamePieces.GetPrivateCard(10, 300);
            objectiveArray[1] = gamePieces.GetPrivateCard(300, 300);
            objectiveArray[2] = gamePieces.GetPublicCard(10, 500);
            objectiveArray[3] = gamePieces.GetPublicCard(300, 500);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            windowPattern.Draw(e.Graphics);

            //foreach (ObjectiveCard o in objectiveArray)
            //        o.Draw(e.Graphics);

            if (gameStarted)
            {
                roundTracker.Draw(e.Graphics);
                draftPool.Draw(e.Graphics);
            }

            foreach (ToolCard t in toolCardArray)
                if (t != null) //TESTING LINE - REMOVE
                    t.Draw(e.Graphics);

            //tool1.Draw(e.Graphics);
            //tool2.Draw(e.Graphics);
            //tool3.Draw(e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (gameStarted)
            {
                if (windowPattern.IsMouseOn(e.X, e.Y))
                {
                    if (selectedDie != null)
                    {
                        int row = windowPattern.GetRow(e.X);
                        int column = windowPattern.GetColumn(e.Y);

                        if (windowPattern.PlacementCheck(selectedDie, row, column))
                        {
                            windowPattern.AddDice(selectedDie, row, column);
                            draftPool.RemoveSelected();
                            selectedDie = null;
                            currentRoundTurn++;
                            windowPattern.IsFirstDice = false;
                        }
                        else
                        {
                            MessageBox.Show("Invalid placement.");
                        }
                    }
                }
                else if (draftPool.IsMouseOn(e.X, e.Y))
                {
                    if (currentRoundTurn < 3)
                    {
                        draftPool.SetSelected(e.X, e.Y);

                        if (draftPool.Selected.Color != Color.White)
                            selectedDie = draftPool.Selected;
                        else
                            ResetSelected();
                    }
                    else
                    {
                        MessageBox.Show("Maximum placements for this round reached.");
                    }
                }
                //Cycles through unplayed dice for the round clicked on
                else if (roundTracker.IsMouseOn(e.X, e.Y))
                {
                    roundTracker.Index(e.X, e.Y);
                }
                else
                {
                    selectedToolCard = GetSelectedToolCard(e.X, e.Y);

                    if (selectedToolCard != null)
                    {
                        if (selectedToolCard is GrozingPliersToolCard)
                        {

                        }
                    }
                    //If mouse is not on any interactive board piece, reset any selected items
                    else
                    {
                        ResetSelected();
                    }
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
            windowPattern = new WindowPattern(gamePieces.GetPreviousRequirements(), 50, 50);
            this.Invalidate();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            windowPattern = new WindowPattern(gamePieces.GetNextRequirements(), 50, 50);
            this.Invalidate();
        }

        private void buttonProceed_Click(object sender, EventArgs e)
        {
            buttonPrevious.Hide();
            buttonNext.Hide();
            buttonProceed.Hide();
            buttonNextRound.Show();

            gameStarted = true;
            this.Invalidate();
        }

        private void buttonNextRound_Click(object sender, EventArgs e)
        {
            foreach (Dice d in draftPool.DiceArray)
                if (d.Color != Color.White)
                    roundTracker.AddDice(roundIndex, d);

            roundIndex++;
            currentRoundTurn = 1;
            toolUsedTurn = 0;

            ResetSelected();

            this.Invalidate();

            if (roundIndex == 10)
            {
                int scoreToBeat = roundTracker.Total;
                int playerScore = 0;

                foreach (ObjectiveCard o in objectiveArray)
                        playerScore += o.Score(windowPattern.TileArray);

                if (playerScore > scoreToBeat)
                    MessageBox.Show("The score to beat was " + scoreToBeat + ".\nYou scored " + playerScore + ".\nYou win!");
                else
                    MessageBox.Show("The score to beat was " + scoreToBeat + ".\nYou scored " + playerScore + ".\nYou lose!");

                MessageBox.Show(objectiveArray[3].Score(windowPattern.TileArray).ToString());

                buttonNextRound.Hide();
                draftPool.Clear();
            }
            else
            {
                draftPool.SetDice(gamePieces.GetDice(), gamePieces.GetDice(), gamePieces.GetDice(), gamePieces.GetDice());
            }
        }

        private void ResetSelected()
        {
            selectedToolCard = null;
            selectedDie = null;
            draftPool.ResetSelected();
        }

        private ToolCard GetSelectedToolCard(int x, int y)
        {
            foreach (ToolCard t in toolCardArray)
                if (t != null) //TESTING LINE - REMOVE
                    if (t.IsMouseOn(x, y))
                        return t;

            return null;
        }
    }
}
