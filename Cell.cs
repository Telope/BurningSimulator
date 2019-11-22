using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    // Each tree in the forest is represented by an instantiation of the Cell class

    class Cell
    {
        // Location of cell on grid
        public int x { get; private set; }
        public int y { get; private set; }

        // The forest
        private Grid grid;

        // Alive = "&"; Burning = "x"; Dead = " ";
        private char status;

        // How long each cell burns for before dying
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

        // Generate a random number to determine whether a cell ignites
        public void AttemptIgnition(Random rng)
        {
            // Randomly generates a number from 1 to 100
            int rand = rng.Next(1, 101);

            if (rand <= burnChance)
            {
                Ignite();
            }
        }

        // Set status to burning and add the cell to the list of burning cells
        public void Ignite()
        {
            grid.AddToBurningCells(this);
            Status = 'x';
        }

        // Set status to dead and remove the cell from the list of burning cel;s
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
