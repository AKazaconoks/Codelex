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
        private static Minesweeper _minesweeper;
        private static int _width;
        private static int _height;
        private static int _mineCount;
        private Board _board;

        [SetUp]
        public void Setup()
        {
            _minesweeper = new Minesweeper();
            _width = 9;
            _height = 9;
            _mineCount = 10;
            _board = new Board(_minesweeper, _width, _height, _mineCount);
        }

        [Test]
        public void TestGameBoard_InitializeBoard_BoardShouldBeCorrectWithMineCountAndClosedCells()
        {
            _board.SetupBoard();
            Assert.AreEqual(_width * _height, _board.Cells.Length);
            foreach (var cell in _board.Cells)
            {
                Assert.IsTrue(cell.CellState == CellState.Closed);
            }

            Assert.AreEqual(_mineCount, _board.NumMines);
        }

        [Test]
        public void TestOpenCell_InitializeBoard_CellShouldChangeToOpen()
        {
            _board.SetupBoard();
            var cell = _board.Cells[0, 0];
            var e = new MouseEventArgs(MouseButtons.Left, 1, cell.XLoc * 50, cell.YLoc * 50, 0);
            _board.Cell_MouseClick(cell, e);
            Assert.IsTrue(cell.CellState == CellState.Opened);
        }

        [Test]
        public void TestGameLoseOnMine_MineCell_GameShouldBeOver()
        {
            _board.SetupBoard();
            var cellMine = _board.Cells[0, 0];
            cellMine.CellType = CellType.Mine;
            var e = new MouseEventArgs(MouseButtons.Left, 1, cellMine.XLoc * 50, cellMine.YLoc * 50, 0);
            _board.Cell_MouseClick(cellMine, e);
            Assert.IsTrue(_board.IsLoseCondition());
            foreach (var cell in _board.Cells)
            {
                if (cell.CellType == CellType.Mine)
                {
                    Assert.IsTrue(cell.CellState == CellState.Opened);
                }
            }
        }

        [Test]
        public void TestGameWinOnAllRegularOpened_OpensAllNonMine_GameShouldWin()
        {
            _board.SetupBoard();
            foreach (var cell in _board.Cells)
            {
                if (cell.CellType != CellType.Mine)
                {
                    var e = new MouseEventArgs(MouseButtons.Left, 1, cell.XLoc * 50, cell.YLoc * 50, 0);
                    _board.Cell_MouseClick(cell, e);
                }
            }

            Assert.IsTrue(_board.IsWinCondition());
        }

        [Test]
        public void TestEmptyCellOpensNeighbours_EmptyCell_ShouldOpenAllNonMineNeighbours()
        {
            _board.SetupBoard();
            var emptyCell = _board.Cells[5, 5];
            emptyCell.NumMines = 0;
            emptyCell.CellType = CellType.Regular;
            var e = new MouseEventArgs(MouseButtons.Left, 1, emptyCell.XLoc * 50, emptyCell.YLoc * 50, 0);
            _board.Cell_MouseClick(emptyCell, e);
            for (var i = 4; i < 7; i++)
            {
                for (var j = 4; j < 7; j++)
                {
                    var neighbourCell = _board.Cells[i, j];
                    if (neighbourCell.CellType != CellType.Mine)
                    {
                        Assert.IsTrue(neighbourCell.CellState == CellState.Opened);
                    }
                    else if (neighbourCell.CellType == CellType.Mine)
                    {
                        Assert.IsTrue(CellState.Closed == neighbourCell.CellState);
                    }
                }
            }
        }
    }
}