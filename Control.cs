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

        public static void RunSimulation()
        {
            Simulation.Run();

            // EndScreen Logic
            bool isValidKey = true;
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

        public static void Quit()
        {
            Environment.Exit(0);
        }

        public static void Options()
        {

            // Change ASCII characters for alive / burnt cells etc.

            // Change how long fires burn for

            bool isValidKey = true;

            Console.Clear();
            DisplayOptions();

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

                    case ConsoleKey.M:
                        return;

                    default:
                        isValidKey = false;
                        break;
                }
            }
        }

        public static void DisplayOptions()
        {
            Console.Clear();
            Console.WriteLine("Options:\n");
            Console.WriteLine("C:\tChange how likely it is for trees to ignite");
            Console.WriteLine("T:\tChange how long the fires burn for");
            Console.WriteLine("\nM:\tBack to Main Menu");
        }

        // Accessor

        public static Grid GetGrid()
        {
            return grid;
        }
    }
}
