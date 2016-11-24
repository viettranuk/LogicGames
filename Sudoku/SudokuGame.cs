using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class SudokuGame
    {
        private static int[,] ReadInput()
        {
            var inputData = new int[9,9];
            var line = 0;

            while (line < 9)
            {
                var row = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(row))
                {
                    var rowArray = row.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);

                    if (rowArray.Length == 9)
                    {
                        for (int col = 0; col < 9; col++)
                        {
                            inputData[line, col] = Convert.ToInt32(rowArray[col]);
                        }

                        line++;
                    }
                }
            }

            return inputData;
        }
        
        public static void Main()
        {
            var testBoard = ReadInput();

            Console.WriteLine();

            var suSol = new SudokuSolver { SudokuBoard = testBoard };

            suSol.Solve();

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
