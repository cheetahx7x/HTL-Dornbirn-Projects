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

        List<Rectangle> Blocks = new List<Rectangle>();

        List<List<Point>> Shapes = new List<List<Point>>();

        List<Point> NextShape = new List<Point>();
        List<Point> CurrentShape = new List<Point>();

        private void Tetris_Load(object sender, EventArgs e)
        {



            
        }

        private void Tetris_Shapes(object sender, EventArgs e)
        {
            picturebox_T.Select();
            //3*3 Box aus Blöcken + 2 Blöcke oben in der Mitte

            Point B1_1 = new Point((picturebox_T.Width / 2) - 50, 0);
            Point B1_2 = new Point((picturebox_T.Width / 2), 0);
            Point B1_3 = new Point((picturebox_T.Width / 2), 50);
            Point B1_4 = new Point((picturebox_T.Width / 2) - 50, 50);











        }

        private void Tetris_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawPolygon(Pens.Transparent, CurrentShape.ToArray());
            e.Graphics.FillPolygon(Brushes.Black, CurrentShape.ToArray());
        }

        private void Preview_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawPolygon(Pens.Transparent, NextShape.ToArray());
            e.Graphics.FillPolygon(Brushes.Black, NextShape.ToArray());
        }

        private void GenerateNextShape()
        {
            Random rnd = new Random();
            CurrentShape = NextShape;
            NextShape = Shapes[rnd.Next(0, (Shapes.Count - 1))];
        }

        private void TestForLines()
        {
            Rectangle RectCollision = new Rectangle();
            RectCollision.Width = 1;
            RectCollision.Height = 1;
            bool bDelete = false;
            for(int i = picturebox_T.Height; i == 0; i -= 50)
            {
                bDelete = false;
                for(int j = picturebox_T.Width; j == 0; i -= 50)
                {
                    RectCollision.X = j;
                    RectCollision.Y = i;

                    if (BlockCollisionDetect(RectCollision))
                    {
                        bDelete = true;
                    }

                }
                if(bDelete == true)
                {
                    DeleteLine(i);
                }
                
            }

        }

        private bool BlockCollisionDetect(Rectangle rectCollider)
        {
            bool bCollision = false;

            foreach(Rectangle rectTarget in Blocks)
            {
                if(rectCollider.IntersectsWith(rectTarget))
                {
                    bCollision = true;
                    break;
                }
            }
            return bCollision;
        }

        private void DeleteLine(int Y)
        {
            //Todo
        }

    }
}
