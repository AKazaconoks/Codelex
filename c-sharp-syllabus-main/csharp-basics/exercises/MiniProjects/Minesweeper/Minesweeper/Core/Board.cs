using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper.Core
{
    public class Board
    {
        public Minesweeper Minesweeper { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int NumMines { get; set; }
        public Cell[,] Cells { get; set; }

        public Board(Minesweeper minesweeper, int width, int height, int mines)
        {
            this.Minesweeper = minesweeper;
            this.Width = width;
            this.Height = height;
            this.NumMines = mines;
            this.Cells = new Cell[width, height];
        }

        public void SetupBoard()
        {
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    var c = new Cell
                    {
                        CellState = CellState.Closed,
                        CellType = CellType.Regular,
                        CellSize = 50,
                        Board = this
                    };
                    c.XLoc = j;
                    c.YLoc = i;
                    c.SetupDesign();
                    c.MouseDown += Cell_MouseClick;
                    this.Cells[i, j] = c;
                    this.Minesweeper.Controls.Add(c);
                }
            }

            var addedMinesCount = 0;
            var random = new Random();
            while (addedMinesCount < this.NumMines)
            {
                var i = random.Next(0, this.Height);
                var j = random.Next(0, this.Width);
                if (this.Cells[i, j].CellType != CellType.Mine)
                {
                    this.Cells[i, j].CellType = CellType.Mine;
                    addedMinesCount++;
                }
            }
            foreach (var cell in Cells)
            {
                setMineCounter(cell);
            }
        }

        private void setMineCounter(Cell cell)
        {
            var counter = 0;
            if (cell.CellType == CellType.Mine)
            {
                return;
            }
            for (var i = Math.Max(0, cell.YLoc - 1); i <= Math.Min(Height - 1, cell.YLoc + 1); i++)
            {
                for (var j = Math.Max(0, cell.XLoc - 1); j <= Math.Min(Width - 1, cell.XLoc + 1); j++)
                {
                    if (i == cell.YLoc && j == cell.XLoc)
                    {
                        continue;
                    }
                    if (Cells[i, j].CellType == CellType.Mine)
                    {
                        counter++;
                    }
                }
            }

            cell.NumMines = counter;
        }

        private void Cell_MouseClick(object sender, MouseEventArgs e)
        {
            var cell = (Cell) sender;

            if (cell.CellState == CellState.Opened)
                return;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    cell.OnClick();
                    GameEnd();
                    OpenZeros(cell);
                    break;

                case MouseButtons.Right:
                    cell.OnFlag();
                    GameEnd();
                    break;

                default:
                    return;
            }

        }

        public void GameEnd()
        {
            if (WinCondition())
            {
                GameEndMessage("You won!");
            }

            if (LoseCondition())
            {
                GameEndMessage("You lost :(");
            }
        }

        public void GameEndMessage(string message)
        {
            var title = "Game Over";
            var result = MessageBox.Show(
                message,
                title,
                MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Question
            );
            switch (result)
            {
                case DialogResult.Retry: // Yes button pressed
                    Application.Restart();
                    break;
                case DialogResult.Cancel: // No button pressed
                    Application.Exit();
                    break;
            }
        }

        public void OpenZeros(Cell cell)
        {
            if (cell.NumMines != 0 || cell.CellType == CellType.Mine)
            {
                return;
            }
            for (var i = Math.Max(0, cell.YLoc - 1); i <= Math.Min(Height - 1, cell.YLoc + 1); i++)
            {
                for (var j = Math.Max(0, cell.XLoc - 1); j <= Math.Min(Width - 1, cell.XLoc + 1); j++)
                {
                    if (i == cell.YLoc && j == cell.XLoc)
                    {
                        continue;
                    }
                    if (Cells[i, j].CellType != CellType.Mine && Cells[i, j].CellType != CellType.Flagged &&
                        Cells[i, j].CellType != CellType.FlaggedMine && Cells[i, j].CellState != CellState.Opened)
                    {
                        Cells[i, j].OnClick();
                        OpenZeros(Cells[i, j]);
                    }
                }
            }
        }
        private bool WinCondition()
        {
            foreach (var cell in Cells)
            {
                if (cell.CellType == CellType.Flagged || 
                    (cell.CellType == CellType.Regular && cell.CellState == CellState.Closed))
                {
                    return false;
                }
            }

            return true;
        }

        private bool LoseCondition()
        {
            foreach (var cell in Cells)
            {
                if (cell.CellType == CellType.Mine && cell.CellState == CellState.Opened)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
