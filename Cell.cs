using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    class Cell
    {
        public int x;
        public int y;
        public char status;

        //Constructor
        public Cell(int xPosition, int yPosition)
        {
            x = xPosition;
            y = yPosition;
        }

        public void AttemptIgnition()
        {
            Random random = new Random();
            int cellIgnites = random.Next(0, 1);

            this.Ignite();
        }

        public void Ignite()
        {
            this.status = 'x';
        }

        public void Die()
        {
            this.status = ' ';
        }



    }
}
