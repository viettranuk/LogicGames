using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class SudokuSolver
    {
        private bool solutionFound = false;

        public static int backTrackCount = 0;
        
        public int[,] SudokuBoard { get; set; }

        private bool ValidInRow(int row, int val)
        {
            for (int col = 0; col < 9; col++)
            {
                if (SudokuBoard[row, col] == val)
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidInCol(int col, int val)
        {
            for (int row = 0; row < 9; row++)
            {
                if (SudokuBoard[row, col] == val)
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidInBlock(int row, int col, int val)
        {
            row = (row / 3) * 3;
            col = (col / 3) * 3;

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (SudokuBoard[row + r, col + c] == val)
                    {
                        return false;
                    }
                }
            }

            return true;
        }        

        private void Solve(int row, int col)
        {
            if (SudokuBoard == null)
            {
                return;
            }
            
            if (row > 8)
            {
                solutionFound = true;
                return;
            }
            else
            {
                while (SudokuBoard[row, col] != 0)
                {
                    if (++col > 8)
                    {
                        col = 0;
                        row++;

                        if (row > 8)
                        {
                            solutionFound = true;
                            return;
                        }
                    }
                }
                
                for (int val = 1; val < 10; val++)
                {
                    if (ValidInRow(row, val) && 
                        ValidInCol(col, val) && ValidInBlock(row, col, val))
                    {
                        SudokuBoard[row, col] = val;

                        if (col < 8)
                        {
                            Solve(row, col + 1);
                        }
                        else
                        {
                            Solve(row + 1, 0);
                        }

                        backTrackCount++;
                    }
                }

                if (!solutionFound)
                {
                    SudokuBoard[row, col] = 0;
                }
            }
        }

        public void Solve()
        {
            Solve(0, 0);
        }
    }
}