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

        private Pen My_Pen = new Pen(Brushes.Black);

        List<List<Point>> Blocks = new List<List<Point>>();

        private void Tetris_Load(object sender, EventArgs e)
        {




            // Docken der Picturebox an die Form
            picturebox_T.Dock = DockStyle.Fill;
            picturebox_T.BackColor = Color.White;

            // Paint Methode
            picturebox_T.Paint += new System.Windows.Forms.PaintEventHandler(this.Tetris_Paint);

            // Picturebox Controls zur Form hinzufügen
            this.Controls.Add(picturebox_T);
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
            Random rnd = new Random();

            //int iRandom = rnd.Next(0, Blocks.Count()-1);
            //e.Graphics.DrawPolygon(My_Pen, Blocks[iRandom].ToArray());
            //e.Graphics.FillPolygon(Brushes.Black, Blocks[iRandom].ToArray());

        }
    }
}
