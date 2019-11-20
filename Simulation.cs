using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    class Simulation
    {
        static private Grid grid;

        static Simulation()
        {
            grid = Control.GetGrid();
        }

        public static void Run()
        {
            grid.Burn();
        }

        public static void DisplayEndScreen()
        {
            grid.Print();
            Console.WriteLine("The fire burned out!");
            Console.WriteLine("The fire burned for " + grid.fireDuration + " ticks");
            Console.WriteLine("At its peak, " + grid.biggestFire + " trees were alight simultaneously.");
            Console.WriteLine("There are " + grid.NumberOfIslands(grid) + " clumps of trees remaining\n");

            // Return to main menu
            Console.WriteLine("Enter:\tRestart Simulation\n" +
                "M:\tMain Menu...");
        }
    }
}
