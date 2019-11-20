using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    class Option
    {
        static private Grid grid;

        //Constructor
        static Option()
        {
            grid = Control.GetGrid();
        }

        public static void FireBurnTime()
        {
            string temp = string.Empty;
            int newBurnTime = Cell.BurnTime;

            Console.Clear();
            Console.WriteLine("Currently, the fires takes " + Cell.BurnTime + " ticks to burn out");
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


            Cell.BurnChance = newBurnChance;

        }


        // &&&& NOT IMPLEMENTED!!!
        internal static void GridSize()
        {
            {
                /*
                    NB: The number of columns and rows shown to the user in this method exclude
                    the empty perimeter (absorbing boundary). The user will be shown and will input
                    the number of filled cells on the grid. To achieve this, it is necessary to
                    subtract and add 2 to some of the values in this method.
                */


                int newX = Grid.numColumns - 2;
                int newY = Grid.numRows - 2;

                Console.Clear();
                Console.WriteLine("Currently, the grid consists of " + newX + " columns and " + newY + " rows >>");
                
                Console.WriteLine("Input the new number of columns >>");
                newX = ReadInput(newX);

                Console.WriteLine("Input the new number of rows >>");
                newY = ReadInput(newY);

                Grid.numColumns = newX + 2;
                Grid.numRows = newY + 2;

            }

        }

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
                    if (output < 0 || output > 255)
                    {
                        Console.WriteLine("Error: Please enter an integer from 1 to 255 >>");
                        inputIsValid = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter an integer from 1 to 255 >>");
                }
            }

            return output;
        }
    }
}
