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
            Grid grid = new Grid(21, 21);
            Control control = new Control();

            Console.WriteLine(
               "Welcome to the fire simulation! \n\n" +
               "Enter:      Start the simulation \n" +
               "Q:          Quit");

            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        grid.Burn();
                        break;

                    case ConsoleKey.Q:
                        control.Quit();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
