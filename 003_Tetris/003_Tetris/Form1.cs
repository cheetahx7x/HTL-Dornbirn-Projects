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
            //Mittlere Blöcke: 250-300, 300-350

            //L-Block Left
            Point LBlock_L1 = new Point(250, 0);
            Point LBlock_L2 = new Point(350, 0);
            Point LBlock_L3 = new Point(350, 150);
            Point LBlock_L4 = new Point(300, 150);
            Point LBlock_L5 = new Point(300, 50);
            Point LBlock_L6 = new Point(250, 50);
            Point LBlock_L7 = new Point(250, 0);

            List<Point> LBlock_L = new List<Point>();
            LBlock_L.Add(LBlock_L1);
            LBlock_L.Add(LBlock_L2);
            LBlock_L.Add(LBlock_L3);
            LBlock_L.Add(LBlock_L4);
            LBlock_L.Add(LBlock_L5);
            LBlock_L.Add(LBlock_L6);
            LBlock_L.Add(LBlock_L7);

            Blocks.Add(LBlock_L);






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
