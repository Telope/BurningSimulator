using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    class Controller
    {
        Grid grid = new Grid(21, 21);
        public Controller()
        {
            MainMenu();

            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        Start();
                        break;

                    case ConsoleKey.O:
                        Options();
                        break;

                    case ConsoleKey.Q:
                        Quit();
                        break;

                    case ConsoleKey.M:
                        MainMenu();
                        break;


                    default:
                        break;
                }
            }
        }

        public void Start()
        {
            grid.Burn();
            SimulationOver();
        }

        private void SimulationOver()
        {
            Console.WriteLine("The fire burned out!");
            Console.WriteLine("There are " + grid.NumberOfIslands(grid) + " clumps of trees remaining");
            
            // Return to main menu
            Console.WriteLine("Press M to return to main menu...");
            while (Console.ReadKey(true).Key != ConsoleKey.M) { }
            MainMenu();
        }

        public void Quit()
        {
            Environment.Exit(0);
        }

        public void Options()
        {
            PrintOptions();

            // Change ASCII characters for alive / burnt cells etc.

            // Change how long fires burn for



            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.F:
                        _Options.FireBurnTime();
                        break;

                    case ConsoleKey.M:
                        return;

                    default:
                        break;
                }
            }
        }

        public static void PrintOptions()
        {
            Console.Clear();
            Console.WriteLine("Options: Press M to return to main menu...");
            Console.WriteLine("F: Change how long the fires burn for");
        }


        public void MainMenu()
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
