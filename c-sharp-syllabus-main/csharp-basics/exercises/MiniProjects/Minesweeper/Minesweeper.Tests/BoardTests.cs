

using FluentAssertions;
using Minesweeper.Core;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Minesweeper.Tests
{
    [TestFixture]
    public class BoardTests
    {
        private static Minesweeper minesweeper = new Minesweeper();
        private static int width = 9;
        private static int height = 9;
        private static int mineCount = 9;
        private Board board = new Board(minesweeper, width, height, mineCount);
        [Test]
        public void TestGameBoard()
        {
            board.SetupBoard();
            Assert.AreEqual(width * height, board.Cells.Length);
            foreach (var cell in board.Cells)
            {
                Assert.IsTrue(cell.CellState == CellState.Closed);
            }
            Assert.AreEqual(mineCount, board.NumMines);
        }

        [Test]
        public void TestOpenCell()
        {
            board.SetupBoard();
            var cell = board.Cells[0, 0];
            cell.OnClick();
            Assert.IsTrue(cell.CellState == CellState.Opened);
        }

        [Test]
        public void TestGameLoseOnMine()
        {
            board.SetupBoard();
            var cellMine = board.Cells[0, 0];
            cellMine.CellType = CellType.Mine;
            cellMine.OnClick();
            Assert.IsTrue(board.LoseCondition());
            foreach (var cell in board.Cells)
            {
                if (cell.CellType == CellType.Mine)
                {
                    Assert.AreEqual(CellState.Opened, cell.CellState);
                }
            }
        }

        [Test]
        public void TestGameWinOnAllRegularOpened()
        {
            board.SetupBoard();
            foreach (var cell in board.Cells)
            {
                if (cell.CellType != CellType.Mine)
                {
                    cell.OnClick();
                }
            }
            Assert.IsTrue(board.WinCondition());
        }

        [Test]
        public void TestEmptyCellOpensNeighbours()
        {
            board.SetupBoard();
            var emptyCell = board.Cells[5, 5];
            emptyCell.NumMines = 0;
            emptyCell.CellType = CellType.Regular;
            emptyCell.OnClick();
            for (var i = 4; i < 7; i++)
            {
                for (var j = 4; j < 7; j++)
                {
                    var neighbourCell = board.Cells[i, j];
                    if (neighbourCell.CellType != CellType.Mine)
                    {
                        Assert.AreEqual(CellState.Opened, neighbourCell.CellState);
                    }
                    else if(board.Cells[i, j].CellType == CellType.Mine)
                    {
                        Assert.AreEqual(CellState.Closed, neighbourCell.CellState);
                    }
                }
            }
        }
    }
}
