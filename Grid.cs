using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    // The forest is an instantiation of the Grid class
    class Grid
    {
        // Used to generate random numbers
        private Random rng = new Random();

        // Array of cells which represent the trees in the forest
        private Cell[,] cells;

        // List of cells which will attempt ignition this tick
        private List<Cell> cellsToBurn = new List<Cell>();
        // List of cells which are burning at the start of this tick
        private List<Cell> burningCells = new List<Cell>();
        // List of cells which will burn out at the end of this tick
        private List<Cell> cellsToDie = new List<Cell>();

        // Dimensions of the Forest (height and width)
        public static int numColumns { get; set; } = 21;
        public static int numRows { get; set; } = 21;

        // Burn Statistics
        // How long the fire lasts
        public int fireDuration {get; private set; }
        // The maximum number of simultaneous fires
        public int biggestFire { get; private set; } 

        // This method handles the logic for the simulation from start to finish
        // Detailed in-line comments outline the sections of this method
        public void Burn()
        {
            // Instantiate cells
            cells = new Cell[numColumns, numRows];
            for (int i = 0; i < numColumns; i++)
            {
                for (int j = 0; j < numRows; j++)
                {
                    cells[i, j] = new Cell(i, j, this);
                }
            }

            // Reset grid and burn statistics and print the starting grid
            fireDuration = 0;
            biggestFire = 0;
            this.Reset();
            CentreCell().Ignite();
            Print();

            // Logic for burning the grid

            // As long as there are cells still burning...
            while (BurningCells.Any())
            {
                // Update the burn statistics
                fireDuration++;
                if (biggestFire < burningCells.Count)
                {
                    biggestFire = burningCells.Count;
                }

                // Spread the fire to the neighbouring trees of each burning cell
                foreach (Cell cell in BurningCells)
                {
                    cell.TimeBurned++;
                    SpreadFire(cell);

                    // If the cell has burned for too long, it will burn out later in this tick
                    if (cell.TimeBurned >= Cell.BurnTime)
                    {
                        cellsToDie.Add(cell);
                    }

                }

                // Any burning cells that have burned for too long burn out
                foreach (Cell cell in CellsToDie)
                {
                    cell.Die();
                }
                cellsToDie.Clear();

                // Each tree next to a burning cell has a chance to start burning
                foreach (Cell cell in CellsToBurn)
                {
                    cell.AttemptIgnition(rng);
                }
                cellsToBurn.Clear();

                // Wait for user input. Placing this check after the logic is calculated
                    // should marginally increase responsiveness
                Console.ReadKey();

                Print();

            }
        }

        // Adds all trees that are adjacent to a burning cell to the list of cells to burn
        private void SpreadFire(Cell cell)
        {
            foreach (Cell neighbour in cell.FindNeighbours())
            {
                if (neighbour.Status == '&')
                {
                    cellsToBurn.Add(neighbour);
                }
            }
        }

        // Method that calculates and returns the middle cell in the grid
        private Cell CentreCell()
        {
            int xMiddle = (int)Math.Ceiling(((numColumns - 1) / 2.0));
            int yMiddle = (int)Math.Ceiling(((numRows - 1) / 2.0));

            return cells[xMiddle, yMiddle];
        }

        // Constructor
        public Grid(int columns, int rows)
        {
            numColumns = columns;
            numRows = rows;
        }

        // Format and print the grid
        public void Print()
        {
            string output = string.Empty;
            Console.Clear();

            for (int j = 0; j < numRows; j++)
            {
                for (int i = 0; i < numColumns; i++)
                {
                    output += cells[i, j].Status + " ";
                }

                output += "\n";
            }

            Console.WriteLine(output);
        }

        // Reset the grid so that all cells apart from the outside edge are '&'
        public void Reset()
        {
            for (int j = 0; j < numRows; j++)
            {
                for (int i = 0; i < numColumns; i++)
                {
                    // Create the Absorbing Boundary Condition of blank cells
                    if (i == 0 || j == 0 || i == numColumns - 1 || j == numRows - 1)
                    {
                        cells[i, j].Status = ' ';
                    }
                    else
                    {
                        cells[i, j].Status = '&';
                    }
                }
            }
        }

        // Calculate the number of contiguous areas of trees (Islands) there are in the finished grid.
        public int NumberOfIslands(Grid grid)
        {
            int numIslands = 0;

            foreach (Cell cell in grid.cells) if (cell.Status == '&')
                {
                    numIslands++;
                    WipeNeighbours(cell);
                }
            return numIslands;
        }

        // Only used in the calculation of NumberOfIslands()
        private void WipeNeighbours(Cell cell)
        {
            cell.Status = ' ';
            foreach (Cell neighbour in cell.FindNeighbours()) if (neighbour.Status == '&')
                {
                    WipeNeighbours(neighbour);
                }
        }

        // Accessors
        public Cell GetCell(int x, int y)
        {
            return cells[x, y];
        }
        public List<Cell> BurningCells
        {
            get { return burningCells; }
        }
        public void AddToBurningCells(Cell cell)
        {
            //Check for an cell in burning cells which has the same x and y value
            // Lambda expression is from an external library#
            // Think of "=>" as meaning "where". (E.g. return burningCell WHERE burningCell.x == cell.x)

            if (!burningCells.Any(burningCell => burningCell.x == cell.x && burningCell.y == cell.y ))
            {
                burningCells.Add(cell);
            }

        }
        public List<Cell> CellsToBurn
        {
            get { return cellsToBurn; }
        }
        public List<Cell> CellsToDie
        {
            get { return cellsToDie; }
        }

        // Mutator
        public void RemoveFromBurningCells(Cell cell)
        {
            burningCells.Remove(cell);
        }
    }
}
