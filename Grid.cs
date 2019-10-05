using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    class Grid
    {
        Cell[,] cells; 
        int numColumns;
        int numRows;
        private string output;

        public void Burn()
        {
            List<Cell> cellsToBurn = new List<Cell>();
            CentreCell().Ignite();

            Print();

            while (true)
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
                    }
                }

                foreach (Cell cell in cellsToBurn)
                {
                    cell.AttemptIgnition();
                }

                Console.ReadKey();
                Console.Clear();
                Print();
            }



            
            
        }

        private Cell CentreCell()
        {
            int xMiddle = (int)Math.Ceiling(((numColumns -1) / 2.0));
            int yMiddle = (int)Math.Ceiling(((numRows- 1) / 2.0));

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
                    output += cells[i, j].status  + " ";
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

        // Use grid to return the 4 cells surrounding this cell
        // TODO: Check that neighbouring cells exist to avoid Boundary errors
        public Cell[] FindNeighboursOf(Cell cell)
        {
            Cell[] neighbours = new Cell[4];
            int x = cell.x;
            int y = cell.y;

            neighbours[0] = cells[x - 1, y];
            neighbours[1] = cells[x, y - 1];
            neighbours[2] = cells[x + 1, y];
            neighbours[3] = cells[x, y + 1];

            return neighbours;
        }
    }
}
