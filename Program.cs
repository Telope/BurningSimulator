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

            grid.Burn();          

            Console.ReadKey();
        }
    }
}
