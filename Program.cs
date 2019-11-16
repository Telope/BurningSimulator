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
            bool isInvalidKey = false;

            while (true)
            {
                if (!isInvalidKey)
                    Control.DisplayMainMenu();

                isInvalidKey = false;

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        Control.Start();
                        break;


                    case ConsoleKey.O:
                        Control.Options();
                        break;

                    case ConsoleKey.Q:
                        Control.Quit();
                        break;

                    default:
                        isInvalidKey = true;
                        break;
                }
            }
        }
    }
}
