using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    class Option
    {
        public static void FireBurnTime()
        {
            string temp = string.Empty;
            int newBurnTime = Cell.BurnTime;

            Console.Clear();
            Console.WriteLine("Currently, the fires takes " + Cell.BurnTime + " ticks to burn out");
            Console.WriteLine("Input the new burn time >>");

            bool inputIsValid = false;
            while (inputIsValid ==false)
            {
                temp = Console.ReadLine();

                try
                {
                    newBurnTime = int.Parse(temp);
                    inputIsValid = true;
                    if (newBurnTime < 1)
                    {
                        Console.WriteLine("Error: Please enter a positive integer >>");
                        inputIsValid = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a positive integer >>");
                }
            }


            Cell.BurnTime = newBurnTime;

        }

        public static void CellBurnChance()
        {
            string temp = string.Empty;
            int newBurnChance = Cell.BurnChance;

            Console.Clear();
            Console.WriteLine("Currently, cells have a  " + Cell.BurnChance + "% chance to burn >>");
            Console.WriteLine("Input the new percentage >>");

            bool inputIsValid = false;
            while (inputIsValid == false)
            {
                temp = Console.ReadLine();

                try
                {
                    newBurnChance = int.Parse(temp);
                    inputIsValid = true;
                    if (newBurnChance < 0 || newBurnChance > 100 )
                    {
                        Console.WriteLine("Error: Please enter a valid percentage >>");
                        inputIsValid = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a valid percentage >>");
                }
            }


            Cell.BurnChance = newBurnChance;

        }

        public static void ChangeChars()
        {
            Console.Clear();
            Console.WriteLine("Currently, trees are represented by '");
        }
    }
}
