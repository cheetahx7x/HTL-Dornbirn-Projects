using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _003_Tetris
{
    public partial class Tetris : Form
    {
        public Tetris()
        {
            InitializeComponent();
        }

        List<List<Point>> Blocks = new List<List<Point>>();

        List<Point> NextBlock = new List<Point>();
        List<Point> CurrentBlock = new List<Point>();

        private void Tetris_Load(object sender, EventArgs e)
        {



            
        }

        private void Tetris_Blocks(object sender, EventArgs e)
        {
            picturebox_T.Select();
            //3*3 Box aus Blöcken + 2 Blöcke oben in der Mitte (Mitte des 3*3 Blocks ist Links neben der Mitte von der Picturebox weil Doppelmitte)

            //Block Rechts Unten
            Point B1_1 = new Point((picturebox_T.Width / 2) - 50, 0);
            Point B1_2 = new Point((picturebox_T.Width / 2), 0);
            Point B1_3 = new Point((picturebox_T.Width / 2), 50);
            Point B1_4 = new Point((picturebox_T.Width / 2) - 50, 50);

            Point B2_1 = new Point((picturebox_T.Width / 2), 0);
            Point B2_2 = new Point((picturebox_T.Width / 2) + 50, 0);
            Point B2_3 = new Point((picturebox_T.Width / 2) + 50, 50);
            Point B2_4 = new Point((picturebox_T.Width / 2), 50);
            











        }

        private void Tetris_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawPolygon(Pens.Transparent, CurrentBlock.ToArray());
            e.Graphics.FillPolygon(Brushes.Black, CurrentBlock.ToArray());
        }

        private void Preview_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawPolygon(Pens.Transparent, NextBlock.ToArray());
            e.Graphics.FillPolygon(Brushes.Black, NextBlock.ToArray());
        }

        private void GenerateNextBlock()
        {
            Random rnd = new Random();
            CurrentBlock = NextBlock;
            NextBlock = Blocks[rnd.Next(0, (Blocks.Count - 1))];
        }
    }
}
