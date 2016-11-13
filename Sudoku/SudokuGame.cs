using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class SudokuGame
    {
        public static void Main(string[] args)
        {
            var simpleTest = new int[9, 9] {

                {0, 4, 0, 0, 0, 0, 1, 3, 2},
                {0, 8, 3, 5, 1, 0, 0, 6, 0},
                {7, 0, 0, 0, 3, 0, 4, 0, 0},
                {0, 0, 4, 3, 9, 7, 0, 0, 0},
                {0, 7, 0, 6, 0, 1, 0, 4, 0},
                {0, 0, 0, 4, 2, 5, 3, 0, 0},
                {0, 0, 2, 0, 5, 0, 0, 0, 4},
                {0, 3, 0, 0, 6, 9, 5, 8, 0},
                {1, 5, 6, 0, 0, 0, 0, 2, 0}
            };

            var evilTest = new int[9, 9] {

                {7, 8, 2, 3, 0, 0, 0, 0, 0},
                {0, 0, 9, 0, 0, 4, 0, 0, 0},
                {3, 0, 6, 0, 0, 9, 0, 0, 0},
                {0, 0, 8, 0, 1, 0, 0, 0, 6},
                {6, 0, 0, 0, 0, 0, 0, 0, 5},
                {2, 0, 0, 0, 4, 0, 1, 0, 0},
                {0, 0, 0, 7, 0, 0, 6, 0, 2},
                {0, 0, 0, 9, 0, 0, 8, 0, 0},
                {0, 0, 0, 0, 0, 1, 7, 3, 9}
            };

            var suSol = new SudokuSolver { SudokuBoard = evilTest };

            suSol.Solve(0, 0);

            if (suSol.SudokuBoard != null)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Console.Write(suSol.SudokuBoard[i,j] + (j < 8 ? " - " : ""));
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("\nBacktrack times: " + SudokuSolver.backTrackCount);
            }

            Console.ReadLine();
        }
    }
}
