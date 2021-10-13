using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada
{
    public class ShadesCard : PublicCard
    {
        int firstNumber, secondNumber;

        public ShadesCard(string type, int x, int y)
        {
            value = 2;

            type = type.ToLower();

            if (type == "light")
            {
                firstNumber = 1;
                secondNumber = 2;
            }
            else if (type == "medium")
            {
                firstNumber = 3;
                secondNumber = 4;
            }
            else if (type == "deep")
            {
                firstNumber = 5;
                secondNumber = 6;
            }
            else
            {
                throw new Exception("Invalid type of shade.");
            }

            left = x;
            top = y;
        }

        public override void Draw(Graphics paper)
        {
            Image img;

            if (firstNumber == 1)
                img = Image.FromFile(@"..\..\Resources\light-shades.jpg");
            else if (firstNumber == 3)
                img = Image.FromFile(@"..\..\Resources\medium-shades.jpg");
            else
                img = Image.FromFile(@"..\..\Resources\deep-shades.jpg");

            paper.DrawImage(img, left, top, CARD_WIDTH, CARD_HEIGHT);
        }

        public override int Score(Tile[,] tileArray)
        {
            int index1 = 0;
            int index2 = 0;

            foreach (Tile t in tileArray)
            {
                if (t.Dice != null)
                {
                    if (t.Dice.Number == firstNumber)
                        index1++;
                    else if (t.Dice.Number == secondNumber)
                        index2++;
                }
            }

            //Returns the lesser occuring of the two numbers as the number of sets
            int sets = index1;

            if (index2 < sets)
                sets = index2;

            return value * sets;
        }
    }
}
