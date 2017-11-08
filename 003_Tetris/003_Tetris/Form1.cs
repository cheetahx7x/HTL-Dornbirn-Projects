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

        List<List<Rectangle>> Shapes = new List<List<Rectangle>>();

        List<Rectangle> NextShape = new List<Rectangle>();
        List<Rectangle> CurrentShape = new List<Rectangle>();

        private void Tetris_Load(object sender, EventArgs e)
        {



            
        }

        private void Tetris_Shapes(object sender, EventArgs e)
        {
            List<Rectangle> Rec_temp = new List<Rectangle>();

            picturebox_T.Select();
            //3*3 Box aus Blöcken + 2 Blöcke oben in der Mitte(Mitte kommt nach dem ersten linken Block weil zweiermitte)

            //Block 1 Unten Links
            Rectangle B1 = new Rectangle((picturebox_T.Width / 2) - 50, 50, 50, 50);

            //Block 2 Unten Mitte
            Rectangle B2 = new Rectangle((picturebox_T.Width / 2), 50, 50, 50);

            //Block 3 Unten Rechts
            Rectangle B3 = new Rectangle((picturebox_T.Width / 2) + 50, 50, 50, 50);

            //Block 4 Mitte Links
            Rectangle B4 = new Rectangle((picturebox_T.Width / 2) - 50, 100, 50, 50);

            //Block 5 Mitte
            Rectangle B5 = new Rectangle((picturebox_T.Width / 2), 100, 50, 50);

            //Block 6 Mitte Rechts
            Rectangle B6 = new Rectangle((picturebox_T.Width / 2) + 50, 100, 50, 50);

            //Block 7 Oben Links
            Rectangle B7 = new Rectangle((picturebox_T.Width / 2) - 50, 150, 50, 50);

            //Block 8 Oben Mitte
            Rectangle B8 = new Rectangle((picturebox_T.Width / 2), 150, 50, 50);

            //Block 9 Oben Rechts
            Rectangle B9 = new Rectangle((picturebox_T.Width / 2) + 50, 150, 50, 50);

            //Block 4.Reihe Mitte
            Rectangle B10 = new Rectangle((picturebox_T.Width / 2), 200, 50, 50);

            //Block 5.Reihe Mitte
            Rectangle B11 = new Rectangle((picturebox_T.Width / 2), 250, 50, 50);

            //I-Shape
            Rec_temp.Add(B2);
            Rec_temp.Add(B5);
            Rec_temp.Add(B8);
            Rec_temp.Add(B10);
            Rec_temp.Add(B11);

            Shapes.Add(Rec_temp);

            //J-Shape
            Rec_temp.Add(B4);
            Rec_temp.Add(B1);
            Rec_temp.Add(B2);
            Rec_temp.Add(B3);

            Shapes.Add(Rec_temp);

            //L-Shape
            Rec_temp.Add(B1);
            Rec_temp.Add(B2);
            Rec_temp.Add(B3);
            Rec_temp.Add(B6);

            Shapes.Add(Rec_temp);

            //O-Shape
            Rec_temp.Add(B1);
            Rec_temp.Add(B2);
            Rec_temp.Add(B4);
            Rec_temp.Add(B5);

            Shapes.Add(Rec_temp);

            //S-Shape
            Rec_temp.Add(B1);
            Rec_temp.Add(B2);
            Rec_temp.Add(B5);
            Rec_temp.Add(B6);

            Shapes.Add(Rec_temp);

            //T-Shape
            Rec_temp.Add(B1);
            Rec_temp.Add(B2);
            Rec_temp.Add(B3);
            Rec_temp.Add(B5);

            Shapes.Add(Rec_temp);

            //Z-Shape
            Rec_temp.Add(B4);
            Rec_temp.Add(B5);
            Rec_temp.Add(B2);
            Rec_temp.Add(B3);

            Shapes.Add(Rec_temp);



        }

        private void Tetris_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            foreach(Rectangle Rect in CurrentShape)
            {
                e.Graphics.DrawRectangle(Pens.Transparent, Rect);
                e.Graphics.FillRectangle(Brushes.Black, Rect);
            }
        }

        private void Preview_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            foreach(Rectangle Rect in CurrentShape)
            {
                e.Graphics.DrawRectangle(Pens.Transparent, Rect);
                e.Graphics.FillRectangle(Brushes.Black, Rect);
            }
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
