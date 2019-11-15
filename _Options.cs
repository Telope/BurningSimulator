using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    class _Options
    {
        public static void FireBurnTime()
        {
            string temp = string.Empty;
            int newBurnTime = Cell.burnTime;

            Console.Clear();
            Console.WriteLine("Currently, the fires takes " + Cell.burnTime + " ticks to burn out");
            Console.WriteLine("Input the new burn time >>");

            bool temptime = false;
            while (temptime ==false)
            {
                temp = Console.ReadLine();

                try
                {
                    newBurnTime = int.Parse(temp);
                    temptime = true;
                    if (newBurnTime < 1)
                    {
                        Console.WriteLine("Error: Please enter a positive integer >>");
                        temptime = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a positive integer >>");
                }
            }

            // Use a Set method *
            Cell.burnTime = newBurnTime;

            BackToOptions();
        }

        private static void BackToOptions()
        {
            Control.DisplayOptions();
        }
    }
}
