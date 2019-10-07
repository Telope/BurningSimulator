using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    class Cell
    {
        // Location of cell on grid
        public int x;
        public int y;
        // Alive '&'; Burning 'x'; Dead ' '.
        public char status;
        // How long the cell burns for before dying
         

        //Constructor
        public Cell(int xPosition, int yPosition)
        {
            x = xPosition;
            y = yPosition;
        }

        public bool AttemptIgnition(Random rng)
        {
            // Randomly 0 or 1
            int cellIgnites =  rng.Next(0, 2);

            if (cellIgnites > 0)
            {
                Ignite();
                return true;
            }
            else
            {
                return false;
            }
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
