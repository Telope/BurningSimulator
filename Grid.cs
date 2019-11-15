using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    class Grid
    {
        Random rng = new Random();

        public Cell[,] cells;

        //<Cell> livingCells = new List<Cell>();
        List<Cell> burningCells = new List<Cell>();
        List<Cell> cellsToBurn = new List<Cell>();
        List<Cell> cellsToDie = new List<Cell>();

        int numColumns;
        int numRows;

        public void Burn()
        {
            Reset();
            CentreCell().Ignite();
            burningCells.Add(CentreCell());

            Print();

            while (burningCells.Any())
            {
                foreach (Cell cell in burningCells)
                {
                    cell.timeBurned++;
                    SpreadFire(cell);

                    if (cell.timeBurned >= Cell.burnTime)
                    {
                        cellsToDie.Add(cell);
                    }

                }

                foreach (Cell cell in cellsToDie)
                {
                    burningCells.Remove(cell);
                    cell.Die();
                }

                cellsToDie.Clear();

                foreach (Cell cell in cellsToBurn)
                {
                    if (cell.AttemptIgnition(rng))
                    {
                        burningCells.Add(cell);
                    }
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
                if (neighbour.status == '&')
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
                    output += cells[i, j].status + " ";
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
                        cells[i, j].status = ' ';
                    }
                    else
                    {
                        cells[i, j].status = '&';
                    }
                }
            }
        }




        // Calculate the number of 'Islands' of trees there are.
        public int NumberOfIslands(Grid grid)
        {
            int numIslands = 0;

            foreach (Cell cell in grid.cells) if (cell.status == '&')
            {
                numIslands++;
                WipeNeighbours(cell);
            }
            return numIslands;
        }

        // Only used in NumberOfIslands()
        private void WipeNeighbours(Cell cell)
        {
            cell.status = ' ';
            foreach (Cell neighbour in cell.FindNeighbours()) if (neighbour.status == '&')
                {
                    WipeNeighbours(neighbour);
                }
        }
    }
}
