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

        Timer timerFalling = new Timer();

        List<Rectangle> Blocks = new List<Rectangle>();

        List<List<Rectangle>> Shapes = new List<List<Rectangle>>();

        List<Rectangle> NextShape = new List<Rectangle>();
        List<Rectangle> CurrentShape = new List<Rectangle>();

        Rectangle rectRotationCenter = new Rectangle();

        private void Tetris_Load(object sender, EventArgs e)
        {
            Tetris_Shapes();
            GenerateNextShape();
            GenerateNextShape();
            timerFalling.Tick += new EventHandler(this.TimerEventFalling);
            timerFalling.Interval = 500;
            timerFalling.Start();
        }


        private void Tetris_Shapes()
        {
            List<Rectangle> Rec_temp = new List<Rectangle>();


            picturebox_T.Select();
            //3*3 Box aus Blöcken + 2 Blöcke oben in der Mitte(Mitte kommt nach dem ersten linken Block weil zweiermitte)

            //Block 1 Unten Links
            Rectangle B1 = new Rectangle((picturebox_T.Width / 2) - 50, -50, 50, 50);

            //Block 2 Unten Mitte
            Rectangle B2 = new Rectangle((picturebox_T.Width / 2), -50, 50, 50);

            //Block 3 Unten Rechts
            Rectangle B3 = new Rectangle((picturebox_T.Width / 2) + 50, -50, 50, 50);

            //Block 4 Mitte Links
            Rectangle B4 = new Rectangle((picturebox_T.Width / 2) - 50, -100, 50, 50);

            //Block 5 Mitte
            Rectangle B5 = new Rectangle((picturebox_T.Width / 2), -100, 50, 50);   //Mitte der Rotation

            //Block 6 Mitte Rechts
            Rectangle B6 = new Rectangle((picturebox_T.Width / 2) + 50, -100, 50, 50);

            //Block 7 Oben Links
            Rectangle B7 = new Rectangle((picturebox_T.Width / 2) - 50, -150, 50, 50);

            //Block 8 Oben Mitte
            Rectangle B8 = new Rectangle((picturebox_T.Width / 2), -150, 50, 50);

            //Block 9 Oben Rechts
            Rectangle B9 = new Rectangle((picturebox_T.Width / 2) + 50, -150, 50, 50);

            //Block 4.Reihe Mitte
            Rectangle B10 = new Rectangle((picturebox_T.Width / 2), -200, 50, 50);

            //I-Shape
            Rec_temp.Add(B2);
            Rec_temp.Add(B5);
            Rec_temp.Add(B8);
            Rec_temp.Add(B10);

            Shapes.Add(Rec_temp);

            Rec_temp = new List<Rectangle>();

            //J-Shape
            Rec_temp.Add(B4);
            Rec_temp.Add(B1);
            Rec_temp.Add(B2);
            Rec_temp.Add(B3);

            Shapes.Add(Rec_temp);

            Rec_temp = new List<Rectangle>();

            //L-Shape
            Rec_temp.Add(B1);
            Rec_temp.Add(B2);
            Rec_temp.Add(B3);
            Rec_temp.Add(B6);

            Shapes.Add(Rec_temp);

            Rec_temp = new List<Rectangle>();

            //O-Shape
            Rec_temp.Add(B1);
            Rec_temp.Add(B2);
            Rec_temp.Add(B4);
            Rec_temp.Add(B5);

            Shapes.Add(Rec_temp);

            Rec_temp = new List<Rectangle>();

            //S-Shape
            Rec_temp.Add(B1);
            Rec_temp.Add(B2);
            Rec_temp.Add(B5);
            Rec_temp.Add(B6);

            Shapes.Add(Rec_temp);

            Rec_temp = new List<Rectangle>();

            //T-Shape
            Rec_temp.Add(B2);
            Rec_temp.Add(B4);
            Rec_temp.Add(B5);
            Rec_temp.Add(B6);

            Shapes.Add(Rec_temp);

            Rec_temp = new List<Rectangle>();

            //Z-Shape
            Rec_temp.Add(B4);
            Rec_temp.Add(B5);
            Rec_temp.Add(B2);
            Rec_temp.Add(B3);

            Shapes.Add(Rec_temp);

            Rec_temp = new List<Rectangle>();

            rectRotationCenter = B5;
        }

        private void Tetris_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            foreach(Rectangle Rect in CurrentShape)
            {
                e.Graphics.DrawRectangle(Pens.Transparent, Rect);
                e.Graphics.FillRectangle(Brushes.Black, Rect);
            }
            foreach (Rectangle Rect in Blocks)
            {
                e.Graphics.DrawRectangle(Pens.Transparent, Rect);
                e.Graphics.FillRectangle(Brushes.Blue, Rect);
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
            List<Rectangle> Rec_temp = new List<Rectangle>();

            Random rnd = new Random();
            CurrentShape = new List<Rectangle>();
            CurrentShape = NextShape;
            NextShape = new List<Rectangle>();
            //NextShape = Shapes[rnd.Next(0, (Shapes.Count - 1))];
            //NextShape = Shapes[0];
            
            Rectangle B2 = new Rectangle((picturebox_T.Width / 2), -50, 50, 50);//Block 3 Unten Rechts
            Rectangle B3 = new Rectangle((picturebox_T.Width / 2) + 50, -50, 50, 50);//Block 4 Mitte Links
            Rectangle B4 = new Rectangle((picturebox_T.Width / 2) - 50, -100, 50, 50); //Block 5 Mitte
            Rectangle B5 = new Rectangle((picturebox_T.Width / 2), -100, 50, 50);   //Mitte der Rotation
            Rectangle B6 = new Rectangle((picturebox_T.Width / 2) + 50, -100, 50, 50);
            Rec_temp.Add(B2);
            Rec_temp.Add(B4);
            Rec_temp.Add(B5);
            Rec_temp.Add(B6);
            NextShape = Rec_temp;
            



            rectRotationCenter = new Rectangle((picturebox_T.Width / 2), -100, 50, 50);
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
                }
            }
            return bCollision;
        }

        private void DeleteLine(int Y)
        {
            foreach(Rectangle rect in Blocks)
            {
                if(rect.Y == Y)
                {
                    Blocks.Remove(rect);
                }
            }
        }

        private void TimerEventFalling(object sender, EventArgs e)
        {
            Rectangle temp = new Rectangle();
            bool bBottom = false;
            bool bCollision = false;

            for(int i = 0; i < CurrentShape.Count; i++)
            {
                temp = CurrentShape[i];
                temp.Y += 50;
                CurrentShape[i] = temp;
            }
            rectRotationCenter.Y += 50;

            foreach (Rectangle rect in CurrentShape)
            {
                if (!(rect.Bottom < picturebox_T.Height))
                {
                    bBottom = true;
                }
            }
            foreach(Rectangle rect in CurrentShape)
            {
                if(BlockCollisionDetect(rect))
                {
                    bCollision = true;
                    bBottom = true;
                }
            }
            
            if(bCollision)
            {
                for (int i = 0; i < CurrentShape.Count; i++)
                {
                    temp = CurrentShape[i];
                    temp.Y -= 50;
                    CurrentShape[i] = temp;
                }
                rectRotationCenter.Y -= 50;
            }

            if(bBottom)
            {
                BottomHit();
            }

            picturebox_T.Invalidate();
        }

        private bool IsCurrentShapeInside()
        {
            bool bInside = true;

            foreach(Rectangle rect in CurrentShape)
            {
                if(rect.X < 0 || rect.Right > picturebox_T.Width)
                {
                    bInside = false;
                }
            }

            return bInside;
        }

        private void Tetris_KeyDown(object sender, KeyEventArgs e)
        {
            Rectangle temp = new Rectangle();

            if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < CurrentShape.Count; i++)
                {
                    temp = CurrentShape[i];
                    temp.X -= 50;
                    CurrentShape[i] = temp;
                }
                rectRotationCenter.X -= 50;

                if (!IsCurrentShapeInside())
                {
                    for (int i = 0; i < CurrentShape.Count; i++)
                    {
                        temp = CurrentShape[i];
                        temp.X += 50;
                        CurrentShape[i] = temp;
                    }
                    rectRotationCenter.X += 50;
                }

            }
            else if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < CurrentShape.Count; i++)
                {
                    temp = CurrentShape[i];
                    temp.X += 50;
                    CurrentShape[i] = temp;
                }
                rectRotationCenter.X += 50;

                if (!IsCurrentShapeInside())
                {
                    for (int i = 0; i < CurrentShape.Count; i++)
                    {
                        temp = CurrentShape[i];
                        temp.X -= 50;
                        CurrentShape[i] = temp;
                    }
                    rectRotationCenter.X -= 50;
                }
            }
            else if(e.KeyCode == Keys.Down && timerFalling.Interval != 200)
            {
                TimerEventFalling(null,null);
                timerFalling.Interval = 200;
            }
            else if(e.KeyCode == Keys.Up)
            {
                SpinShape();
            }


            picturebox_T.Invalidate();
        }

        private void Tetris_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                timerFalling.Interval = 1000;
            }
        }

        private void SpinShape()
        {
            Rectangle temp = new Rectangle();
            bool bLeftOutside = false;
            bool bRightOutside = false;

            for(int i = 0; i < CurrentShape.Count; i++)
            {
                temp = CurrentShape[i];
                temp.Y = rectRotationCenter.Y + (CurrentShape[i].X - rectRotationCenter.X);
                temp.X = rectRotationCenter.X - (CurrentShape[i].Y - rectRotationCenter.Y);
                CurrentShape[i] = temp;
            }

            foreach (Rectangle rect in CurrentShape)
            {
                if (rect.X < 0)
                {
                    bLeftOutside = true;
                }
                if (rect.Right > picturebox_T.Width)
                {
                    bRightOutside = true;
                }
            }

            if(bLeftOutside)
            {
                for (int j = 0; bLeftOutside; j++)
                {
                    for (int i = 0; i < CurrentShape.Count(); i++)
                    {
                        temp = CurrentShape[i];
                        temp.X += 50;
                        CurrentShape[i] = temp;
                    }
                    rectRotationCenter.X += 50;

                    foreach (Rectangle rect in CurrentShape)
                    {
                        if (rect.X >= 0)
                        {
                            bLeftOutside = false;
                        }
                    }
                }
            }
            if (bRightOutside)
            {
                for (int j = 0; bRightOutside; j++)
                {
                    for (int i = 0; i < CurrentShape.Count(); i++)
                    {
                        temp = CurrentShape[i];
                        temp.X -= 50;
                        CurrentShape[i] = temp;
                    }
                    rectRotationCenter.X -= 50;

                    foreach (Rectangle rect in CurrentShape)
                    {
                        if (rect.Right <= picturebox_T.Width)
                        {
                            bRightOutside = false;
                        }
                    }
                }
            }

        }

        private void BottomHit()
        {
            foreach(Rectangle rect in CurrentShape)
            {
                Blocks.Add(rect);
            }
            GenerateNextShape();
        }
    }
}
