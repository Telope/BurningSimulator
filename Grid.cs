using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    // The grid contains an array of cells

    class Grid
    {
        private Random rng = new Random();

        private Cell[,] cells;

        private List<Cell> cellsToBurn = new List<Cell>();
        private List<Cell> burningCells = new List<Cell>();
        private List<Cell> cellsToDie = new List<Cell>();

        private int numColumns;
        private int numRows;

        public void Burn()
        {
            Reset();
            CentreCell().Ignite();

            Print();

            while (BurningCells.Any())
            {
                

                foreach (Cell cell in BurningCells)
                {
                    cell.TimeBurned++;
                    SpreadFire(cell);

                    if (cell.TimeBurned >= Cell.BurnTime)
                    {
                        cellsToDie.Add(cell);
                    }

                }

                foreach (Cell cell in CellsToDie)
                {
                    cell.Die();
                }

                cellsToDie.Clear();

                foreach (Cell cell in CellsToBurn)
                {
                    cell.AttemptIgnition(rng);
                }

                cellsToBurn.Clear();

                Console.ReadKey();

                Print();

            }
        }

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

            cells = new Cell[numColumns, numRows];

            for (int i = 0; i < numColumns; i++)
            {
                for (int j = 0; j < numRows; j++)
                {
                    cells[i, j] = new Cell(i, j, this);
                }
            }

            this.Reset();
        }

        // Format and print the grid
        private void Print()
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




        // Calculate the number of 'Islands' of trees there are.
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

        // Only used in NumberOfIslands()
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
            burningCells.Add(cell);
        }
        public void RemoveFromBurningCells(Cell cell)
        {
            burningCells.Remove(cell);
        }

        public List<Cell> CellsToBurn
        {
            get { return cellsToBurn; }
        }

        public List<Cell> CellsToDie
        {
            get { return cellsToDie; }
        }
    }
}
