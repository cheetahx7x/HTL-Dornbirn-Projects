using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace _004_Throw
{
    public partial class Umgebung : Form
    {
        public Umgebung()
        {
            InitializeComponent();
        }

        List<float> Circle1 = new List<float>();

        List<PointF> C1Points = new List<PointF>();

        Region Circle1_Region = new Region();

        Random r = new Random();

        List<PointF> Play_Area = new List<PointF>();

        List<PointF> Solid = new List<PointF>();

        Region Solid_Region = new Region();

        Region Play_Area_Region = new Region();

        PointF point = new PointF();

        RectangleF Tank1 = new RectangleF();

        RectangleF Tank2 = new RectangleF();

        PictureBox pic = new PictureBox();

        Timer TimerKeyDown = new Timer();

        int iInc = 3;

        bool bUpKey;
        bool bDownKey;
        bool bLeftKey;
        bool bRightKey;

        bool bWKey;
        bool bSKey;
        bool bAKey;
        bool bDKey;

        bool bSpace;

        int iRefreshRate = 2;
        //int iParabolaLength = 70;

        float fGravity = 3f;
        int iTimeSteps = 5;
        float fxspeed = 500;
        float fyspeed = 60;

        //float fxsimspeed = 0;
        //float fysimspeed = 0;

        Timer timerGravity = new Timer();
        Timer timerRefresh = new Timer();

        //PointF pointMouse = new PointF();

        private void Umgebung_Load(object sender, EventArgs e)
        {
            TimerKeyDown.Tick += new EventHandler(this.TimerKeyDownEvent);
            TimerKeyDown.Interval = 10;
            TimerKeyDown.Start();

            timerRefresh.Interval = iRefreshRate;
            timerRefresh.Tick += new EventHandler(this.TimerRefreshEvent);
            timerRefresh.Start();

            timerGravity.Interval = iTimeSteps;
            timerGravity.Tick += new EventHandler(this.TimerGravityEvent);

            Generate_PlayArea();
            Generate_Solid();
            Generate_Tanks();

            pic.Paint += new PaintEventHandler(this.pic_Paint);

            //pic.MouseClick += new MouseEventHandler(this.Umgebung_MouseClick);

            //pointMouse = new PointF(Circle1[0], Circle1[1]);
        }

        /*

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.LightPink, Color.DeepPink, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        */


        private void Generate_Tanks()
        {
            Tank1.Height = 15;
            Tank2.Height = 15;
            Tank1.Width = 25;
            Tank2.Width = 25;
            Tank1.Location = new Point(this.Width - 85, this.Height - 75);
            Tank2.Location = new Point(45, this.Height - 75);

            // Docken der Picturebox an die Form
            pic.Dock = DockStyle.Fill;
            pic.BackColor = Color.White;

            // Paint Methode
            pic.Paint += new System.Windows.Forms.PaintEventHandler(this.Umgebung_Paint);

            // Picturebox Controls zur Form hinzufügen
            this.Controls.Add(pic);

            Circle1.Add(Tank1.Location.X+Tank1.Width/2);
            Circle1.Add(Tank1.Location.Y);
            Circle1.Add(3);
        }

        private void Generate_Solid()
        {
            PointF p1 = new PointF(0, this.Height - 60);
            PointF p2 = new PointF(Play_Area[6].X, this.Height - 60);
            PointF p3 = new PointF(Play_Area[6].X, this.Height - 140);
            PointF p4 = new PointF(Play_Area[4].X, this.Height - 140);
            PointF p5 = new PointF(Play_Area[4].X, this.Height - 60);
            PointF p6 = new PointF(this.Width, this.Height - 60);
            PointF p7 = new PointF(this.Width, this.Height);
            PointF p8 = new PointF(0, this.Height);
            PointF p9 = new PointF(0, this.Height - 60);

            Solid.Add(p1);
            Solid.Add(p2);
            Solid.Add(p3);
            Solid.Add(p4);
            Solid.Add(p5);
            Solid.Add(p6);
            Solid.Add(p7);
            Solid.Add(p8);
            Solid.Add(p9);
        }

        private void Generate_PlayArea()
        {
            PointF p1 = new PointF(0, 0);
            PointF p2 = new PointF(this.Width, 0);
            PointF p3 = new PointF(this.Width, this.Height - 60);
            PointF p4 = new PointF(r.Next(100, this.Width - 100), this.Height - 60);
            PointF p5 = new PointF(p4.X, this.Height - 140);
            PointF p6 = new PointF(p5.X - 20, this.Height - 140);
            PointF p7 = new PointF(p6.X, this.Height - 60);
            PointF p8 = new PointF(0, this.Height - 60);
            PointF p9 = new PointF(0, 0);

            Play_Area.Add(p1);
            Play_Area.Add(p2);
            Play_Area.Add(p3);
            Play_Area.Add(p4);
            Play_Area.Add(p5);
            Play_Area.Add(p6);
            Play_Area.Add(p7);
            Play_Area.Add(p8);
            Play_Area.Add(p9);
        }

        private void Umgebung_Resize(object sender, EventArgs e)
        {
            Tank1.X = ((Tank1.X / Play_Area[1].X) * this.Width);
            Tank1.Y = this.Height - 75;

            Tank2.X = ((Tank2.X / Play_Area[1].X) * this.Width);
            Tank2.Y = this.Height - 75;

            if(timerGravity.Enabled == false)
            {
                Circle1[0] = Tank1.X + Tank1.Width / 2;
                Circle1[1] = Tank1.Y;
            }

            //pointMouse.X = (pointMouse.X / Play_Area[1].X) * this.Width;
            //pointMouse.Y = (pointMouse.Y / Play_Area[2].Y) * (this.Height-60);

            point.X = (Play_Area[3].X / Play_Area[1].X) * this.Width; point.Y = this.Height - 60;
            Play_Area[3] = point;
            point.X = this.Width; point.Y = 0;
            Play_Area[1] = point;
            point.X = this.Width; point.Y = this.Height - 60;
            Play_Area[2] = point;
            point.X = Play_Area[3].X; point.Y = this.Height - 140;
            Play_Area[4] = point;
            point.X = Play_Area[4].X - 20; point.Y = this.Height - 140;
            Play_Area[5] = point;
            point.X = Play_Area[5].X; point.Y = this.Height - 60;
            Play_Area[6] = point;
            point.X = 0; point.Y = this.Height - 60;
            Play_Area[7] = point;

            point.X = 0; point.Y = this.Height - 60;
            Solid[1] = point;
            point.X = Play_Area[5].X; point.Y = this.Height - 60;
            Solid[2] = point;
            point.X = Play_Area[5].X; point.Y = this.Height - 140;
            Solid[3] = point;
            point.X = Play_Area[3].X; point.Y = this.Height - 140;
            Solid[4] = point;
            point.X = Play_Area[3].X; point.Y = this.Height - 60;
            Solid[5] = point;
            point.X = this.Width; point.Y = this.Height - 60;
            Solid[6] = point;
            point.X = this.Width; point.Y = this.Height;
            Solid[7] = point;
            point.X = 0; point.Y = this.Height;
            Solid[8] = point;
        }

        void pic_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath g = new GraphicsPath();
            g.AddRectangle(this.ClientRectangle);

            using (PathGradientBrush brush = new PathGradientBrush(g))
            {
                point.X = 0;
                point.Y = 0;
                brush.CenterPoint = point;
                brush.CenterColor = Color.LightGoldenrodYellow;
                Color[] colors = { Color.DeepSkyBlue };
                brush.SurroundColors = colors;
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                e.Graphics.FillPolygon(Brushes.Gray, Solid.ToArray());

                path.AddPolygon(Solid.ToArray());

                Solid_Region = new Region(path);
            }

            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddPolygon(Play_Area.ToArray());

                Play_Area_Region = new Region(path);
            }

            e.Graphics.FillRectangle(Brushes.Red, Tank1);

            e.Graphics.FillRectangle(Brushes.ForestGreen, Tank2);


            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                e.Graphics.FillCircle(Brushes.Black, Circle1);

                for (int i = 0; i < 360; i += 30)
                {
                    point.X = (float)(Circle1[2] * Math.Cos(i * Math.PI / 180F)) + Circle1[0];
                    point.Y = (float)(Circle1[2] * Math.Sin(i * Math.PI / 180F)) + Circle1[1];
                    C1Points.Add(point);
                }
                path.AddPolygon(C1Points.ToArray());
                Circle1_Region = new Region(path);
            }
            //point.X = Circle1[0];
            //point.Y = Circle1[1];
            //e.Graphics.DrawLine(Pens.Black, pointMouse, point);
            C1Points.Clear();
        }

        private void Umgebung_Paint(object sender, PaintEventArgs e)
        {
            /*
            GraphicsPath g = new GraphicsPath();
            g.AddPolygon(Play_Area.ToArray());

            PathGradientBrush My_Brush = new PathGradientBrush(g);

            My_Brush.CenterPoint = new PointF(0, 0);
            My_Brush.CenterColor = Color.DeepSkyBlue;
            Color[] colors = { Color.LightGoldenrodYellow };
            My_Brush.SurroundColors = colors;

            e.Graphics.FillPolygon(My_Brush, Play_Area.ToArray());
            */
        }

        private void Umgebung_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            {
                //pointMouse.X = e.X;
                //pointMouse.Y = e.Y;
                // Geschwindigkeit aufgrund der Mausposition ermitteln
                //fxspeed = (pointMouse.X - Circle1[1]);
                //fyspeed = (pointMouse.Y - Circle1[2]);
            }
        }

        private void Umgebung_KeyDown(object sender, KeyEventArgs e)
        {
            if (TimerKeyDown.Enabled == false) { TimerKeyDown.Start(); }

            if (e.KeyCode == Keys.Up) { bUpKey = true; }
            if (e.KeyCode == Keys.Down) { bDownKey = true; }
            if (e.KeyCode == Keys.Left) { bLeftKey = true; }
            if (e.KeyCode == Keys.Right) { bRightKey = true; }
            if (e.KeyCode == Keys.W) { bWKey = true; }
            if (e.KeyCode == Keys.S) { bSKey = true; }
            if (e.KeyCode == Keys.A) { bAKey = true; }
            if (e.KeyCode == Keys.D) { bDKey = true; }
            if (e.KeyCode == Keys.Space) { bSpace = true; }
        }

        private void Umgebung_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { bUpKey = false; }
            if (e.KeyCode == Keys.Down) { bDownKey = false; }
            if (e.KeyCode == Keys.Left) { bLeftKey = false; }
            if (e.KeyCode == Keys.Right) { bRightKey = false; }
            if (e.KeyCode == Keys.W) { bWKey = false; }
            if (e.KeyCode == Keys.S) { bSKey = false; }
            if (e.KeyCode == Keys.A) { bAKey = false; }
            if (e.KeyCode == Keys.D) { bDKey = false; }
            if (e.KeyCode == Keys.Space) { bSpace = false; }

            if (bUpKey == false && bDownKey == false && bLeftKey == false && bRightKey == false && bWKey == false && bSKey == false && bAKey == false && bDKey == false && bSpace == false) { TimerKeyDown.Stop(); TimerKeyDown.Enabled = false; }
        }

        private bool Intersect(RectangleF rect)
        {
            bool bIntersect = false;
            if (Solid_Region.IsVisible(rect))
            {
                bIntersect = true;
            }
            return bIntersect;
        }

        private bool Intersect_Circle()
        {
            bool bIntersect =false;
            for (int i = 0; i < C1Points.Count; i++)
            {
                if (Solid_Region.IsVisible(C1Points[i]))
                {
                    bIntersect = true;
                }
            }
            return bIntersect;
        }

        private bool Intersect_Circle_Bounds()
        {
            bool bIntersect = false;
            for (int i = 0; i < C1Points.Count; i++)
            {
                if (Play_Area_Region.IsVisible(C1Points[i]))
                {
                    bIntersect = false;
                }
                else
                {
                    bIntersect = true;
                }
            }
            return bIntersect;
        }

        private void TimerRefreshEvent(object sender, EventArgs e)
        {
            pic.Invalidate();
        }

        private void TimerKeyDownEvent(object sender, EventArgs e)
        {
            // Bewegung des fahrbaren Rechtecks durch Tastendrücke
            if (bUpKey)
            {

            }
            if (bDownKey)
            {
                
            }
            if (bLeftKey)
            {
                Tank1.X = Tank1.X - iInc;

                for (int i = 0; Intersect(Tank1) || Tank1.X <= 0; i++)
                {
                    Tank1.X = Tank1.X + i;
                }

            }
            if (bRightKey)
            {
                Tank1.X = Tank1.X + iInc;

                for (int i = 0; Intersect(Tank1) || Tank1.X >= this.Width - 40; i++)
                {
                    Tank1.X = Tank1.X - i;
                }
            }

            if (bWKey)
            {

            }
            if (bSKey)
            {

            }
            if (bAKey)
            {
                Tank2.X = Tank2.X - iInc;

                for (int i = 0; Intersect(Tank2) || Tank2.X <= 0; i++)
                {
                    Tank2.X = Tank2.X + i;
                }

            }
            if (bDKey)
            {
                Tank2.X = Tank2.X + iInc;

                for (int i = 0; Intersect(Tank2) || Tank2.X >= this.Width - 40; i++)
                {
                    Tank2.X = Tank2.X - i;
                }
            }
            if(bSpace)
            {
                //timerGravity.Start();
            }
        }

        private void TimerGravityEvent(object sender, EventArgs e)
        {
            // Neue Geschwindigkeit nach Beschleunigung ausrechnen
            fyspeed = fyspeed + ((fGravity / 2) * (iTimeSteps));
            // Bewegung in Y-Richtung nach Geschwindigkeit
            Circle1[1] = Circle1[1] + (fyspeed * (iTimeSteps * 0.005f));
            // Bewegung in X-Richtung nach Geschwindigkeit
            Circle1[0] = Circle1[0] + (fxspeed * (iTimeSteps * 0.005f));

            // Kollisionstest Solid Region
            if (Intersect_Circle() == true)
            {
                // Bewegung Rückgängig machen
                Circle1[1] = Circle1[1] - (fyspeed * (iTimeSteps * 0.005f));
                Circle1[0] = Circle1[0] - (fxspeed * (iTimeSteps * 0.005f));
                //Bewegung stoppen
                fyspeed = 0;
                fxspeed = 0;
            }

            // Kollisionstest Bounds
            if (Intersect_Circle_Bounds() == true)
            {
                // Bewegung Rückgängig machen
                Circle1[0] = Circle1[0] - (fxspeed * (iTimeSteps * 0.005f));
                // Geschwindigkeit umkehren und verringern (Abprallen)
                fxspeed = -fxspeed * 0.3f;
            }

            // Kollisionstest des Ziels
            if (Circle1_Region.IsVisible(Tank2))
            {
                timerGravity.Stop();
            }

        }

        private void btn_fire_Click(object sender, EventArgs e)
        {
            if(txt_winkel.Text != ""||txt_speed.Text != "")
            {
                try
                {
                    fxspeed = (-1) * (float)(Math.Cos(Math.PI*double.Parse(txt_winkel.Text)/180) * double.Parse(txt_speed.Text));
                    fyspeed = (-1) * (float)(Math.Sin(Math.PI*double.Parse(txt_winkel.Text)/180) * double.Parse(txt_speed.Text));
                    timerGravity.Start();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Bitte geben Sie alle Werte ein!", "FEHLER!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
    public static class GraphicsExtensions
    {
        public static void DrawCircle(this Graphics g, Pen pen, List<float> Circle)
        {
            g.DrawEllipse(pen, Circle[0] - Circle[2], Circle[1] - Circle[2], Circle[2] + Circle[2], Circle[2] + Circle[2]);
        }

        public static void FillCircle(this Graphics g, Brush brush, List<float> Circle)
        {
            g.FillEllipse(brush, Circle[0] - Circle[2], Circle[1] - Circle[2], Circle[2] + Circle[2], Circle[2] + Circle[2]);
        }
    }
}
