using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    // Methods in the Control class carry out the actions listed in the main menu
        // (from the Program Class)

    class Control
    {
        // The forest
        private static Grid grid;

        //Handles starting and repeating the simulation, returning  to main menu
        public static void RunSimulation()
        {
            grid = new Grid(Grid.numColumns, Grid.numRows);

            Simulation.Run();

            // EndScreen Logic

            // The user input is a valid menu option
            bool isValidKey = true;
            // The user has chosen to rerun the simulation
            bool isRepeatSimulation = false;
            while (true)
            {
                if (isRepeatSimulation)
                {
                    Simulation.Run();
                    isRepeatSimulation = false;
                }

                if (isValidKey)
                {
                    Simulation.DisplayEndScreen();
                    isValidKey = true;
                }
                isValidKey = true;

                switch (Console.ReadKey(true).Key)
                {

                    case ConsoleKey.Enter:
                        isRepeatSimulation = true;
                        break;

                    case ConsoleKey.M:
                        return;

                    default:
                        isValidKey = false;
                        break;
                }
            }

        }

        // Help screen: explanation / instructions / legend
        internal static void DisplayHelp()
        {
            Console.Clear();
            Console.WriteLine("Help:\n\n" +
                "This application simulates a fire in a forest >>\n" +
                "Once you press Enter from the main menu, the grid will appear >>\n\n" +
                "The symbols in the grid represent the following:\n" +
                "&:     A living tree;\n" +
                "x:     A burning tree;\n" +
                " :     An empty space >>\n\n" +
                "During the simulation, press any key to advance the fire >>\n" +
                "After the fire has burned out, some statistics will be displayed about the fire >>\n" +
                "It is possible to change some parameters that govern the fire from the Options menu >>\n\n" +
                "Press any key to return to the main menu...");

            Console.ReadKey();
        }

        // Quit the program
        public static void Quit()
        {
            Environment.Exit(0);
        }

        // Logic for the Options menu
        public static void Options()
        {
            Console.Clear();
            DisplayOptions();

            // The user input is a valid menu option
            bool isValidKey = true;

            while (true)
            {
                if (isValidKey)
                    DisplayOptions();

                isValidKey = true;

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.T:
                        Option.FireBurnTime();
                        break;

                    case ConsoleKey.C:
                        Option.CellBurnChance();
                        break;

                    case ConsoleKey.D:
                        Option.GridSize();
                        break;

                    case ConsoleKey.M:
                        return;

                    default:
                        isValidKey = false;
                        break;
                }
            }
        }

        // Display the Options menu
        public static void DisplayOptions()
        {
            Console.Clear();
            Console.WriteLine("Options:\n");
            Console.WriteLine("C:\tChange how likely it is for trees to ignite");
            Console.WriteLine("T:\tChange how long the fires burn for");
            Console.WriteLine("D:\tChange the size of the grid");
            Console.WriteLine("\nM:\tBack to Main Menu");
        }

        // Accessor
        public static Grid GetGrid()
        {
            return grid;
        }
    }
}
