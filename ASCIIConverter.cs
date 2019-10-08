using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    class ASCIIConverter
    {
        public static int toNumber(char input)
        {
            int output = Convert.ToInt32(input);

            return output;
        }
        public static char toChar(int input)
        {
            char output = Convert.ToChar(input);

            return output;
        }
    }
}
