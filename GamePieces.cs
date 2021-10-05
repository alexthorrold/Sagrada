using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sagrada
{
    public class GamePieces
    {
        List<Dice> diceList;
        List<WindowPattern> windowList;

        int diceIndex = 0;
        int windowIndex = 0;

        public GamePieces()
        {
            diceList = new List<Dice>();

            //Adds the 90 dice to the list of dice
            for (int i = 0; i < 18; i++)
            {
                diceList.Add(new Dice(Color.Red, i % 6 + 1));
            }
            for (int i = 0; i < 18; i++)
            {
                diceList.Add(new Dice(Color.Blue, i % 6 + 1));
            }
            for (int i = 0; i < 18; i++)
            {
                diceList.Add(new Dice(Color.Green, i % 6 + 1));
            }
            for (int i = 0; i < 18; i++)
            {
                diceList.Add(new Dice(Color.Purple, i % 6 + 1));
            }
            for (int i = 0; i < 18; i++)
            {
                diceList.Add(new Dice(Color.Yellow, i % 6 + 1));
            }

            windowList = new List<WindowPattern>
            {

            };

            RandomiseOrder();
        }

        public void RandomiseOrder()
        {
            List<Dice> randomList = new List<Dice>();
            int n = 90;
            int r;
            Random rand = new Random();

            while (n > 0)
            {
                r = rand.Next(n);
                randomList.Add(diceList[r]);
                diceList.RemoveAt(r);
                n--;
            }

            diceList = randomList;
        }

        public Dice GetDice()
        {
            Dice d = diceList[diceIndex];
            diceIndex++;
            return d;
        }

        public WindowPattern GetWindow()
        {
            WindowPattern w = windowList[windowIndex];
            windowIndex++;
            return w;
        }
    }
}
