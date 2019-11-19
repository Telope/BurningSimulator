using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main Menu Logic
            bool isValidKey = true;
            while (true)
            {
                if (isValidKey)
                    DisplayMainMenu();

                isValidKey = true;

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        Control.RunSimulation();
                        break;

                    case ConsoleKey.O:
                        Control.Options();
                        break;

                    case ConsoleKey.Q:
                        Control.Quit();
                        break;

                    default:
                        isValidKey = false;
                        break;
                }
            }
        }

        public static void DisplayMainMenu()
        {
            string mainmenu = "Welcome to the fire simulation! \n\n" +
                               "Enter:  Start the simulation \n" +
                               "O:      Options \n" +
                               "Q:      Quit";

            Console.Clear();
            Console.WriteLine(mainmenu);
        }
    }
}
