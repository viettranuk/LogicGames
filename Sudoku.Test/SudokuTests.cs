﻿using System;
using NUnit.Framework;

namespace Sudoku.Test
{
    [TestFixture]
    public class SudokuTests
    {
        private SudokuSolver solver;
        private int[,] simpleTestBoard, simpleTestBoardSolution;
        private int[,] evilTestBoard, evilTestBoardSolution;
        
        [SetUp]
        public void Init() 
        {
            solver = new SudokuSolver();

            simpleTestBoard = new int[9, 9] {
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

            simpleTestBoardSolution = new int[9, 9] {
                {9, 4, 5, 8, 7, 6, 1, 3, 2},
                {2, 8, 3, 5, 1, 4, 7, 6, 9},
                {7, 6, 1, 9, 3, 2, 4, 5, 8},
                {5, 2, 4, 3, 9, 7, 8, 1, 6},
                {3, 7, 9, 6, 8, 1, 2, 4, 5},
                {6, 1, 8, 4, 2, 5, 3, 9, 7},
                {8, 9, 2, 1, 5, 3, 6, 7, 4},
                {4, 3, 7, 2, 6, 9, 5, 8, 1},
                {1, 5, 6, 7, 4, 8, 9, 2, 3}
            };

            evilTestBoard = new int[9, 9] {
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

            evilTestBoardSolution = new int[9, 9] {
                {7, 8, 2, 3, 5, 6, 9, 4, 1},
                {5, 1, 9, 8, 7, 4, 2, 6, 3},
                {3, 4, 6, 1, 2, 9, 5, 7, 8},
                {4, 9, 8, 5, 1, 7, 3, 2, 6},
                {6, 7, 1, 2, 9, 3, 4, 8, 5},
                {2, 5, 3, 6, 4, 8, 1, 9, 7},
                {9, 3, 4, 7, 8, 5, 6, 1, 2},
                {1, 6, 7, 9, 3, 2, 8, 5, 4},
                {8, 2, 5, 4, 6, 1, 7, 3, 9}
            };
        }
        
        [Test]
        public void Given_OneSimpleBoard_Then_CorrectSolutionReturned()
        {
            solver.SudokuBoard = simpleTestBoard;
            solver.Solve();

            Assert.That(solver.SudokuBoard, Is.EqualTo(simpleTestBoardSolution));
        }

        [Test]
        public void Given_OneEvilBoard_Then_CorrectSolutionReturned()
        {
            solver.SudokuBoard = evilTestBoard;
            solver.Solve();

            Assert.That(solver.SudokuBoard, Is.EqualTo(evilTestBoardSolution));
        }
    }
}
