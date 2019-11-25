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
            // Attributes

        // The forest
        private Grid grid;

        // Location of cell on grid
        private int x;
        private int y;

        // Alive = "&"; Burning = "x"; Dead = " ";
        private char status;

        // How long a cell has been burning
        private int timeBurned;

        // How likely cells are to ignite (1 to 100)
        private static int burnChance = 50;

        // How long each cell burns for before dying
        private static int burnTime = 1;

            // Methods

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
            SetStatus('x');
        }

        // Set status to dead and remove the cell from the list of burning cel;s
        public void Die()
        {
            grid.RemoveFromBurningCells(this);
            timeBurned = 0;
            SetStatus(' ');
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

            // Accessors

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public char GetStatus()
        {
            return status;
        }

        public int GetTimeBurned()
        {
            return timeBurned;
        }

        public static int GetBurnTime()
        {
            return burnTime;

        }

        public static int GetBurnChance()
        {
            return burnChance;

        }

            // Mutators

        public void SetStatus(char _status)
        {
            if (_status == '&' || _status == 'x' || _status == ' ')
            {
                status = _status;
            }

        }

        public void SetTimeBurned(int _timeBurned)
        {
            timeBurned = _timeBurned;
        }

        public static void SetBurnTime(int _burnTime)
        {
            if (_burnTime > 0 && _burnTime < 10)
            {
                burnTime = _burnTime;
            }
        }

        public static void SetBurnChance(int _burnChance)
        {
            if (_burnChance > 0 && _burnChance <= 100)
            {
                burnChance = _burnChance;
            }
        }

    }
}
