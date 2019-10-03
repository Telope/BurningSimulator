using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningSimulator
{
    class Grid
    {
        char[,] cells;
        int numColumns;
        int numRows;
        private string output;

        public void Burn()
        {
            FindCentre();
            Print();
        }

        private void FindCentre()
        {
            
        }

        // Constructor
        public Grid(int columns, int rows)
        {
            numColumns = columns;
            numRows = rows;

            cells = new char[numRows, numColumns];

            this.Reset();
        }

        // Format and print the grid
        public void Print()
        {
            int i = 0;

            foreach (char cell in cells)
            {
                output += cell;
                i++;

                // Add a new line after each row
                if (i == numColumns)
                {
                    output += "\n";
                    i = 0;
                }

                // Add a blank space after every character
                else
                {
                    output += " ";
                }
            }

            Console.WriteLine(output);
        }

        // Reset the grid so that all cells apart from the outside edge are '&'
        public void Reset()
        {
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    if (i == 0 || j == 0 || i == numRows - 1 || j == numColumns - 1)
                    {
                        cells[i, j] = ' ';
                    }
                    else
                    {
                        cells[i, j] = '&';
                    }
                    

                }
            }
        }
    }
}
