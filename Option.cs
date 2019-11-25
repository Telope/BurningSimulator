using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    // Methods in the Option class carry out the actions listed in the options menu
        // (from the Control Class)

    static class Option
    {
        // The forest
        static private Grid grid;

        // Constructor
        static Option()
        {
            grid = Control.GetGrid();
        }

        // Change how long each tree can burn for before burning out
        public static void FireBurnTime()
        {
            string temp = string.Empty;

            // Return value is the current value if no change is made.
            int newBurnTime = Cell.GetBurnTime();

            Console.Clear();
            Console.WriteLine("Currently, the fires takes " + Cell.GetBurnTime() + " ticks to burn out");
            Console.WriteLine("Input the new burn time >>");

            bool inputIsValid = false;
            while (inputIsValid == false)
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


            Cell.SetBurnTime(newBurnTime);

        }

        // Changes how likely each tree is to burn when next to a burning tree
        public static void CellBurnChance()
        {
            string temp = string.Empty;

            // Updated burn chance is the same as the old one if no changes are made
            int newBurnChance = Cell.GetBurnChance();

            Console.Clear();
            Console.WriteLine("Currently, cells have a  " + Cell.GetBurnChance() + "% chance to burn >>");
            Console.WriteLine("Input the new percentage >>");

            bool inputIsValid = false;
            while (inputIsValid == false)
            {
                temp = Console.ReadLine();

                try
                {
                    newBurnChance = int.Parse(temp);
                    inputIsValid = true;
                    if (newBurnChance < 0 || newBurnChance > 100)
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


            Cell.SetBurnChance(newBurnChance);

        }


        // Change the dimensions of the grid (width and height)
        public static void GridSize()
        {
            {
                /*
                    NB: The number of columns and rows shown to the user in this method exclude
                    the empty perimeter (absorbing boundary). The user will be shown and will input
                    the number of filled cells on the grid. To achieve this, it is necessary to
                    subtract and add 2 to some of the values in this method.
                */


                int newX = Grid.GetNumColumns() - 2;
                int newY = Grid.GetNumRows() - 2;

                Console.Clear();
                Console.WriteLine("Currently, the grid consists of " + newX + " columns and " + newY + " rows >>");
                
                Console.WriteLine("Input the new number of columns >>");
                newX = ReadInput(newX);

                Console.WriteLine("Input the new number of rows >>");
                newY = ReadInput(newY);

                Grid.SetNumColumns(newX + 2);
                Grid.SetNumRows(newY + 2);

            }

        }

        // Handles inputs in the GridSize option screen
                // In the future, this method could be modified to handle all user input
        private static int ReadInput(int oldValue)
        {
            string temp = string.Empty;
            bool inputIsValid = false;
            int output = oldValue;

            while (inputIsValid == false)
            {
                temp = Console.ReadLine();

                try
                {
                    output = int.Parse(temp);
                    inputIsValid = true;
                    if (output < 0 || output > 100)
                    {
                        Console.WriteLine("Error: Please enter an integer from 1 to 100 >>");
                        inputIsValid = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter an integer from 1 to 100 >>");
                }
            }

            return output;
        }
    }
}
