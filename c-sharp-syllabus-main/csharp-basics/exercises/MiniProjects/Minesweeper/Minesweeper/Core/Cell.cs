using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper.Core
{
    public enum CellType
    {
        Regular, Mine, Flagged, FlaggedMine
    }

    public enum CellState
    {
        Opened, Closed
    }

    public class Cell : Button
    {
        public int XLoc { get; set; }
        public int YLoc { get; set; }
        public int CellSize { get; set; }
        public CellState CellState { get; set; }
        public CellType CellType { get; set; }
        public int NumMines { get; set; }
        public Board Board { get; set; }

        public void SetupDesign()
        {
            this.BackColor = SystemColors.ButtonFace;
            this.Location = new Point(XLoc * CellSize, YLoc * CellSize);
            this.Size = new Size(CellSize, CellSize);
            this.UseVisualStyleBackColor = false;
            this.Font = new Font("Verdana", 15.75F, FontStyle.Bold);
        }

        public void OnFlag()
        {
            if (this.CellType == CellType.Flagged)
            {
                this.CellType = CellType.Regular;
                this.Text = "";
                this.BackColor = ColorTranslator.FromHtml("0xffffff");
            }
            else if (this.CellType == CellType.FlaggedMine)
            {
                this.CellType = CellType.Mine;
                this.Text = "";
                this.BackColor = ColorTranslator.FromHtml("0xffffff");
            }
            else if (this.CellType == CellType.Regular)
            {
                this.CellType = CellType.Flagged;
                this.Text = "?";
                this.ForeColor = ColorTranslator.FromHtml("0xffffff");;
                this.BackColor = ColorTranslator.FromHtml("#A9A9A9");
            }
            else if (this.CellType == CellType.Mine)
            {
                this.CellType = CellType.FlaggedMine;
                this.Text = "?";
                this.ForeColor = ColorTranslator.FromHtml("0xffffff");;
                this.BackColor = ColorTranslator.FromHtml("#A9A9A9");
            }
        }

        public void OnClick(bool recursiveCall = false)
        {
            this.CellState = CellState.Opened;
            if (this.CellType == CellType.Mine)
            {
                this.Text = "*";
                this.ForeColor = GetCellColour();
                this.BackColor = ColorTranslator.FromHtml("#D3D3D3");
            }
            else
            {
                this.Text = this.NumMines == 0 ? "" : $"{this.NumMines}";
                this.ForeColor = GetCellColour();
                this.BackColor = ColorTranslator.FromHtml("#D3D3D3");
            }
        }
        
        private Color GetCellColour()
        {
            switch (this.NumMines)
            {
                case 1:
                    return ColorTranslator.FromHtml("0x0000FE");
                case 2:
                    return ColorTranslator.FromHtml("0x186900");
                case 3:
                    return ColorTranslator.FromHtml("0xAE0107");
                case 4:
                    return ColorTranslator.FromHtml("0x000177");
                case 5:
                    return ColorTranslator.FromHtml("0x8D0107");
                case 6:
                    return ColorTranslator.FromHtml("0x007A7C");
                case 7:
                    return ColorTranslator.FromHtml("0x902E90");
                case 8:
                    return ColorTranslator.FromHtml("0x000000");
                default:
                    return ColorTranslator.FromHtml("0xffffff");
            }
        }
    }
}
