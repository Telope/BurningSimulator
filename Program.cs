using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    // Program is the entry point of the program and contains the main menu
    static class Program
    {
        // Program entry point and logic for main menu
        static void Main(string[] args)
        {
            // Main menu Logic

            // The user input is a valid menu option
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

                    case ConsoleKey.H:
                        Control.DisplayHelp();
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

        // Display the main menu
        public static void DisplayMainMenu()
        {
            string mainmenu = "Welcome to the fire simulation! \n\n" +
                               "Enter:  Start the simulation \n" +
                               "O:      Options \n" +
                               "H:      Help\n" +
                               "Q:      Quit";

            Console.Clear();
            Console.WriteLine(mainmenu);
        }
    }
}
