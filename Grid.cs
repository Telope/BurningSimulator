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
        Cell[,] cells;

        int numColumns;
        int numRows;



        private string output;

        public void Burn()
        {
            List<Cell> burningCells = new List<Cell>();
            List<Cell> cellsToBurn = new List<Cell>();

            CentreCell().Ignite();
            burningCells.Add(CentreCell());

            Print();

            while (burningCells.Any())
            {
                foreach (Cell cell in cells)
                {
                    if (cell.status == 'x')
                    {
                        foreach (Cell neighbour in FindNeighboursOf(cell))
                        {
                            if (neighbour.status == '&')
                            {
                                cellsToBurn.Add(neighbour);
                            }
                        }

                        cell.status = ' ';
                    }
                }
                int test = burningCells.Count;
                burningCells.Clear();

                foreach (Cell cell in cellsToBurn)
                {
                    if (cell.AttemptIgnition(rng))
                    {
                        burningCells.Add(cell);
                    }
                }

                cellsToBurn.Clear();

                Console.ReadKey();
                Console.Clear();
                Print();
                Console.WriteLine(test);
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
                    cells[i, j] = new Cell(i, j);
                }
            }

            this.Reset();
        }

        // Format and print the grid
        public void Print()
        {
            output = string.Empty;

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
                    /*// Create the Absorbing Boundary Condition of blank cells
                    if (i == 0 || j == 0 || i == numColumns - 1 || j == numRows - 1)
                    {
                        cells[i, j].status = ' ';
                    }
                    else*/
                    {
                        cells[i, j].status = '&';
                    }
                }
            }
        }

        // Use grid to return the 4 cells surrounding this cell
        // TODO: Check that neighbouring cells exist to avoid Boundary errors
        public List<Cell> FindNeighboursOf(Cell cell)
        {
            List<Cell> neighbours = new List<Cell>();
            int x = cell.x;
            int y = cell.y;

            try { neighbours.Add(cells[x - 1, y]); }
            catch (IndexOutOfRangeException) { }

            try { neighbours.Add(cells[x, y - 1]); }
            catch (IndexOutOfRangeException) { }

            try { neighbours.Add(cells[x + 1, y]); }
            catch (IndexOutOfRangeException) { }

            try { neighbours.Add(cells[x, y + 1]); }
            catch (IndexOutOfRangeException) { }

            return neighbours;
        }
    }
}
