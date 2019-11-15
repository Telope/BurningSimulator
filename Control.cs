using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    class Control
    {
        static Grid grid = new Grid(21, 21);

        public static void Start()
        {
            Control.grid.Burn();
            SimulationOver();
        }

        private static void SimulationOver()
        {
            Console.WriteLine("The fire burned out!");
            Console.WriteLine("There are " + grid.NumberOfIslands(grid) + " clumps of trees remaining");
            
            // Return to main menu
            Console.WriteLine("Enter:   Restart Simulation\nM: Main Menu...");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Enter:
                    Control.Start();    // Will this create a stack?
                    break;

                case ConsoleKey.M:
                    return;             // I want the switch to wait for a valid input rather than 
            }
        }

        public static void Quit()
        {
            Environment.Exit(0);
        }

        public static void Options()
        {

            // Change ASCII characters for alive / burnt cells etc.

            // Change how long fires burn for



            while (true)
            {
                Console.Clear();
                DisplayOptions();

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.T:
                        Option.FireBurnTime();
                        break;

                    case ConsoleKey.C:
                        Option.CellBurnChance();
                        break;

                    case ConsoleKey.Enter:
                        return;

                    default:
                        break;
                }
            }
        }

        public static void DisplayOptions()
        {
            Console.Clear();
            Console.WriteLine("Options: Press Enter to return to main menu...\n");
            Console.WriteLine("C:\tChange how likely it is for trees to ignite");
            Console.WriteLine("T:\tChange how long the fires burn for");
        }

        public static void DisplayMainMenu()
        {
            string mainmenu =  "Welcome to the fire simulation! \n\n" +
                               "Enter:  Start the simulation \n" +
                               "O:      Options \n" +
                               "Q:      Quit";

            Console.Clear();
            Console.WriteLine(mainmenu);
        }
    }
}
