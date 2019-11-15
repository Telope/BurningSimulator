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
        Grid grid;
        private char _status;

        // Alive '&'; Burning 'x'; Dead ' '.
        public char status
        {
            get { return _status; }
            set
            {
                //if (value != '&'  || value != 'x' || value != ' ') {
                //    throw new Exception();
                //}
                _status = value;
            }
        }

        // How long the cell burns for before dying
        public static int burnTime = 1;
        // How long a cell has been burning
        public int timeBurned;

        //Constructor
        public Cell(int xPosition, int yPosition, Grid tempGrid)
        {
            x = xPosition;
            y = yPosition;
            grid = tempGrid;
            timeBurned = 0;
        }

        public bool AttemptIgnition(Random rng)
        {
            // Randomly 0 or 1
            int cellIgnites = rng.Next(0, 2);

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
            status = 'x';
        }

        public void Die()
        {
            timeBurned = 0;
            status = ' ';
        }

        // Use grid to return the 4 cells surrounding this cell
        public List<Cell> FindNeighbours()
        {
            List<Cell> neighbours = new List<Cell>();

            try { neighbours.Add(grid.cells[x - 1, y]); }
            catch (IndexOutOfRangeException) { }

            try { neighbours.Add(grid.cells[x, y - 1]); }
            catch (IndexOutOfRangeException) { }

            try { neighbours.Add(grid.cells[x + 1, y]); }
            catch (IndexOutOfRangeException) { }

            try { neighbours.Add(grid.cells[x, y + 1]); }
            catch (IndexOutOfRangeException) { }

            return neighbours;

        }
    }
}
