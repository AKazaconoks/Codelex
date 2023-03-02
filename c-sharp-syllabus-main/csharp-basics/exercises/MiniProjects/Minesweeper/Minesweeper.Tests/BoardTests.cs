

using System.Threading;
using System.Windows.Forms;
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
        private static int mineCount = 10;
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
            var e = new MouseEventArgs(MouseButtons.Left, 1, cell.XLoc*50, cell.YLoc*50, 0);
            board.Cell_MouseClick(cell, e);
            Assert.IsTrue(cell.CellState == CellState.Opened);
        }

        [Test]
        public void TestGameLoseOnMine()
        {
            board.SetupBoard();
            var cellMine = board.Cells[0, 0];
            cellMine.CellType = CellType.Mine;
            var e = new MouseEventArgs(MouseButtons.Left, 1, cellMine.XLoc*50, cellMine.YLoc*50, 0);
            board.Cell_MouseClick(cellMine, e);
            Assert.IsTrue(board.LoseCondition());
            foreach (var cell in board.Cells)
            {
                if (cell.CellType == CellType.Mine)
                {
                    Assert.IsTrue(cell.CellState == CellState.Opened);
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
                    var e = new MouseEventArgs(MouseButtons.Left, 1, cell.XLoc*50, cell.YLoc*50, 0);
                    board.Cell_MouseClick(cell, e);
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
            var e = new MouseEventArgs(MouseButtons.Left, 1, emptyCell.XLoc*50, emptyCell.YLoc*50, 0);
            board.Cell_MouseClick(emptyCell, e);
            for (var i = 4; i < 7; i++)
            {
                for (var j = 4; j < 7; j++)
                {
                    var neighbourCell = board.Cells[i, j];
                    if (neighbourCell.CellType != CellType.Mine)
                    {
                        Assert.IsTrue(neighbourCell.CellState == CellState.Opened);
                    }
                    else if(neighbourCell.CellType == CellType.Mine)
                    {
                        Assert.IsTrue(CellState.Closed == neighbourCell.CellState);
                    }
                }
            }
        }
    }
}
