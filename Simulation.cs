using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    //  Methods in the Simulation class carry out the actions related to running the simulation 
            //(from the RunSimulation() method in the Control Class)
    class Simulation
    {
        // The forest
        static private Grid grid;

        // Constructor
        static Simulation()
        {
            grid = Control.GetGrid();
        }

        // Start the Simulation
        public static void Run()
        {
            grid.Burn();
        }

        // Display the end screen
            // (Logic for this menu is in Control.RunSimulation())
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
