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
        private int x;
        private int y;
        private Grid grid;
        private char status;

        // How long the cell burns for before dying
        private static int burnTime = 1;
        // How long a cell has been burning
        private int timeBurned;
        // How likely cells are to ignite (1 to 100)
        private static int burnChance = 50;

        //Constructor
        public Cell(int xPosition, int yPosition, Grid tempGrid)
        {
            x = xPosition;
            y = yPosition;
            grid = tempGrid;
            timeBurned = 0;
        }

        public void AttemptIgnition(Random rng)
        {
            // Randomly generates a number from 1 to 100
            int rand = rng.Next(1, 101);

            if (rand <= burnChance)
            {
                Ignite();
            }
        }

        public void Ignite()
        {
            grid.AddToBurningCells(this);
            Status = 'x';
        }

        public void Die()
        {
            grid.RemoveFromBurningCells(this);
            timeBurned = 0;
            Status = ' ';
        }

        // Use grid to return the 4 cells surrounding this cell
        public List<Cell> FindNeighbours()
        {
            List<Cell> neighbours = new List<Cell>();

            try { neighbours.Add(grid.GetCell(x - 1, y)); }
            catch (IndexOutOfRangeException) { }

            try { neighbours.Add(grid.GetCell(x, y - 1)); }
            catch (IndexOutOfRangeException) { }

            try { neighbours.Add(grid.GetCell(x + 1, y)); }
            catch (IndexOutOfRangeException) { }

            try { neighbours.Add(grid.GetCell(x, y + 1)); }
            catch (IndexOutOfRangeException) { }

            return neighbours;

        }

        // Accessors and Mutators

        // Alive '&'; Burning 'x'; Dead ' '.
        public char Status
        {
            get { return status; }
            set
            {
                if (value == '&'  || value == 'x' || value == ' ') 
                {
                    status = value;
                }
                
            }
        }

        public static int BurnTime
        {
            get { return burnTime; }
            set
            {
                if (value > 0 && value < 10)
                {
                    burnTime = value;
                }
            }
        }

        public int TimeBurned
        {
            get { return timeBurned; }
            set
            {
                timeBurned = value;
            }
        }

        public static int BurnChance
        {
            get { return burnChance; }
            set 
            { 
                if (value > 0 && value <= 100)
                {
                    burnChance = value;
                }
            }
        }

    }
}
