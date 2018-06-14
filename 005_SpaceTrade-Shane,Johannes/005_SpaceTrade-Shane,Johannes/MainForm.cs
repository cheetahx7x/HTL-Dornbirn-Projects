using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Reflection;

namespace _005_SpaceTrade_Shane_Johannes
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public struct Linkclick
        {
            public string name;
            public int anfang;
            public int ende;
        };

        public struct Ellipse
        {
            public float width;
            public float height;
            public double angle;
        };

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            this.BringToFront();
            this.Focus();
            txt_Username.Location = new Point(this.Width / 2 - txt_Username.Width / 2, this.Height / 2 - txt_Username.Height / 2);
            txt_Password.Location = new Point(this.Width / 2 - txt_Password.Width / 2, this.Height / 2 + txt_Password.Height / 2);
            btn_Login.Location = new Point(this.Width / 2 - btn_Login.Width / 2, this.Height / 2 + 2 * txt_Password.Height);
            txt_Fehler.Location = new Point(txt_Username.Location.X + txt_Username.Width + 10, txt_Username.Location.Y + txt_Username.Height / 2);
        }

        Rectangle ScreenSize = new Rectangle(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
        DBConnection conon = new DBConnection("5.9.13.41", "c", "Rvmk9!17", "spacetrade");
        ClientDB conof = new ClientDB();
        List<Linkclick> Links = new List<Linkclick>();
        Linkclick tmpLink = new Linkclick();
        Size Modulesize = new Size(203, 95);
        Point center = new Point();
        Pen Grey = new Pen(Brushes.LightGray);
        List<Ellipse> ellipses = new List<Ellipse>();
        List<PointF> planets = new List<PointF>();
        List<PictureBox> Modules = new List<PictureBox>();
        List<Image> Assets = new List<Image>();
        Random rnd = new Random();
        Timer Planettick = new Timer();

        private void MainForm_Load(object sender, EventArgs e)
        {
            Planettick.Tick += new EventHandler(Planettick_Tick);
            Planettick.Interval = 100;
            Planettick.Enabled = true;

            center.X = ScreenSize.Width / 2;
            center.Y = ScreenSize.Height / 2;
            Create_Modules();

            Assets.Add(_005_SpaceTrade_Shane_Johannes.Properties.Resources.spaceshipm1);
            Assets.Add(_005_SpaceTrade_Shane_Johannes.Properties.Resources.SUN);
            Assets.Add(_005_SpaceTrade_Shane_Johannes.Properties.Resources.spacenice1);
            Assets.Add(_005_SpaceTrade_Shane_Johannes.Properties.Resources.spacenice2);
            Assets.Add(_005_SpaceTrade_Shane_Johannes.Properties.Resources.spaceniceS1);

            txt_main.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, 0);
            string Text = "Du hast noch keinen Account? Registrieren";
            Add_Link("Registrieren", Text.Length - "Registrieren".Length, Text.Length);
            WriteText(txt_main, Text, Links, 1);
        }

        private void Planettick_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i<ellipses.Count(); i++)
            {
                if(ellipses[i].angle >= 180)
                {
                    Ellipse tmp = new Ellipse();
                    tmp.height = ellipses[i].height;
                    tmp.width = ellipses[i].width;
                    tmp.angle = -180;
                    ellipses[i] = tmp;
                }
                else
                {
                    Ellipse tmp = new Ellipse();
                    tmp.height = ellipses[i].height;
                    tmp.width = ellipses[i].width;
                    tmp.angle = ellipses[i].angle + 0.2;
                    ellipses[i] = tmp;
                }
            }
            Get_Planet_Points();
        }

        private void Create_Modules()
        {
            Modules.Add(Module1);
            Modules.Add(Module2);
            Modules.Add(Module3);
            Modules.Add(Module4);
            Modules.Add(Module5);
            Modules.Add(Module6);
            Modules.Add(Module7);
            Modules.Add(Module8);
            Modules[0].Click += new EventHandler(Module1_Click);
            Modules[1].Click += new EventHandler(Module2_Click);
            Modules[2].Click += new EventHandler(Module3_Click);
            Modules[3].Click += new EventHandler(Module4_Click);
            Modules[4].Click += new EventHandler(Module5_Click);
            Modules[5].Click += new EventHandler(Module6_Click);
            Modules[6].Click += new EventHandler(Module7_Click);
            Modules[7].Click += new EventHandler(Module8_Click);
            Hide_Modules(Modules.Count());
        }

        private int Randomint(int first, int last)
        {
            return rnd.Next(first, last+1);
        }

        private void CreateEllipses()
        {
            float Ratio = ((float)ScreenSize.Width / (float)ScreenSize.Height);
            bool bshit;
            int count = Randomint(3, 7);
            Ellipse ellipse = new Ellipse();
            do
            {
                do
                {
                    bshit = false;
                    ellipse.height = Randomint(200, ScreenSize.Height - 100);
                    ellipse.width = ellipse.height * Ratio;
                    ellipse.angle = Randomint(-180, 180);

                    for (int i = 0; i < ellipses.Count(); i++)
                    {
                        if (ellipse.height > ellipses[i].height - 70 && ellipse.height < ellipses[i].height + 70)
                        {
                            bshit = true;
                        }
                    }
                } while (bshit == true);
                ellipses.Add(ellipse);
            } while (ellipses.Count() < count);
        }

        private void WriteText(LinkLabel Label, string message, List<Linkclick> Buttons, int speed)
        {
            Label.Links.Clear();
            string tmp = "";
            var index = 0;
            var timer = new System.Timers.Timer(speed);
            timer.Elapsed += delegate {
                if (index < message.Length)
                {
                    if (Label.InvokeRequired == true)
                        Label.Invoke((MethodInvoker)delegate
                        {
                            tmp = tmp + message[index];
                            Label.Text = tmp;
                            Label.LinkArea = new LinkArea(0, 0);
                            if (index == message.Length - 1)
                            {
                                for (int i = 0; i < Buttons.Count(); i++)
                                {
                                    Label.Links.Add(Buttons[i].anfang, Buttons[i].ende);
                                    Label.Links[i].Name = Buttons[i].name;
                                }
                            }
                            index++;
                        });
                }
                else
                {
                    timer.Enabled = false;
                    timer.Dispose();
                }
            };
            timer.Enabled = true;
        }

        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private void Inventory()
        {
            string Text = "Inventar\n\n";

            List<string> Erze = conof.Select("SELECT * FROM m_Erze", 1);
            List<string> Materialien = conof.Select("SELECT * FROM m_Materialien", 1);

            foreach (string s in Erze)
            {
                Text = Text + s + "\n";
            }

            WriteText(txt_inventory, Text, new List<Linkclick>(), 1);
        }

        private void txt_main_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link.Name == "Registrieren")
            {
                txt_Fehler.Text = "";
                btn_Login.Text = "Register";
                string Text = "Du hast schon einen Account? Login";
                Clear_Links();
                Add_Link("Login", Text.Length - "Login".Length, Text.Length);
                WriteText(txt_main, Text, Links, 1);
            }

            if(e.Link.Name == "Login")
            {
                txt_Fehler.Text = "";
                btn_Login.Text = "Login";
                string Text = "Du hast noch keinen Account? Registrieren";
                Clear_Links();
                Add_Link("Registrieren", Text.Length - "Registrieren".Length, Text.Length);
                WriteText(txt_main, Text, Links, 1);
            }
        }

        private void Add_Link(string name, int anf, int end)
        {
            tmpLink.name = name;
            tmpLink.anfang = anf;
            tmpLink.ende = end;
            Links.Add(tmpLink);
        }

        private void Clear_Links()
        {
            Links.Clear();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if(btn_Login.Text == "Login")
            {
                txt_Password.ReadOnly = true;
                txt_Username.ReadOnly = true;
                if(conon.DBUserCheck(txt_Username.Text, GetHashString(txt_Password.Text)) == true)
                {
                    conon.connect();
                    conon.DBTuningServerClient(txt_Username.Text);
                    conon.disconnect();
                    txt_Password.Dispose();
                    txt_Username.Dispose();
                    txt_Fehler.Visible = false;
                    btn_Login.Dispose();
                    txt_main.Text = "";
                    Gamestart();
                }
                else
                {
                    txt_Fehler.Text = "Der Username oder das Passwort ist falsch!";
                    txt_Password.ReadOnly = false;
                    txt_Username.ReadOnly = false;
                }
            }

            if(btn_Login.Text == "Register")
            {
                txt_Password.ReadOnly = true;
                txt_Username.ReadOnly = true;
                conon.connect();
                List<string> tmp = conon.Select("SELECT * FROM benutzer", 1);
                conon.disconnect();
                if (txt_Username.Text.Length >= 3 && txt_Username.Text.Length <= 20)
                {
                    if (txt_Password.Text.Length >= 6 && txt_Password.Text.Length <= 20)
                    {
                        bool b = false;
                        for (int i = 0; i < tmp.Count(); i++)
                        {
                            if (txt_Username.Text == tmp[i])
                            {
                                b = true;
                            }
                        }
                        if(b == false)
                        {
                            conon.connect();
                            conon.Update("INSERT INTO benutzer (name,pw) VALUES ('" + txt_Username.Text + "','" + GetHashString(txt_Password.Text) + "')");
                            conon.DBAbgleichServerClientFirst();
                            conon.disconnect();
                            txt_Password.Dispose();
                            txt_Username.Dispose();
                            txt_Fehler.Visible = false;
                            btn_Login.Dispose();
                            txt_main.Text = "";
                            WriteText(txt_main, "Es herrscht ein Krieg und du und deine Zivilisation seid gezwungen von deinem Heimatplaneten zu fliehen. Der Krieg breitet sich immer weiter aus und so musst ihr immer weiter weg fliehen. Ihr warpt in konfliktlose Bereiche, die dadurch leider immer sehr Resourcenarm sind. Deswegen werden kleine Schiffe losgeschickt die Resourcen sammeln, um das Überleben von deiner Zivilisation sicherzustellen und du bist der Captain einer dieser Schiffe.", new List<Linkclick>(), 50);
                            System.Threading.Thread.Sleep(5000);
                            txt_main.Text = "";
                            Gamestart();
                        }
                        else
                        {
                            txt_Fehler.Text = "Der Username ist bereits vergeben!";
                            txt_Password.ReadOnly = false;
                            txt_Username.ReadOnly = false;
                        }
                    }
                    else
                    {
                        txt_Fehler.Text = "Das Passwort muss mindestens 6 und darf maximal 20 Zeichen lang sein!";
                        txt_Password.ReadOnly = false;
                        txt_Username.ReadOnly = false;
                    }
                }
                else
                {
                    txt_Fehler.Text = "Der Benutzername muss mindestens 3 und darf maximal 20 Zeichen lang sein!";
                    txt_Password.ReadOnly = false;
                    txt_Username.ReadOnly = false;
                }
            }
        }

        private void Show_Modules(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                Modules[i].Enabled = true;
                Modules[i].Visible = true;
            }
        }

        private void Hide_Modules(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                Modules[i].Enabled = false;
                Modules[i].Visible = false;
            }
        }

        private void Mothership_show()
        {
            Main_Picture.Enabled = true;
            Main_Picture.Image = Assets[0];
            Main_Picture.Visible = true;
            Show_Modules(4);
            Main_Picture.Width = Assets[0].Width;
            Main_Picture.Height = Assets[0].Height;
            Main_Picture.Location = new Point(ScreenSize.Width / 2 - Main_Picture.Size.Width / 2, ScreenSize.Height / 2 - Main_Picture.Size.Height / 2);
            for(int i = 0; i<4;i++)
            {
                Modules[i].Size = Modulesize;
                Modules[i].MaximumSize = new Size(1000, 1000);
                Modules[i].BackColor = Color.Red;
                Modules[i].Show();
            }
            Modules[0].Location = new Point(Main_Picture.Location.X + 156, Main_Picture.Location.Y + 165);
            Modules[1].Location = new Point(Main_Picture.Location.X + 369, Main_Picture.Location.Y + 270);
            Modules[2].Location = new Point(Main_Picture.Location.X + 156, Main_Picture.Location.Y + 270);
            Modules[3].Location = new Point(Main_Picture.Location.X + 369, Main_Picture.Location.Y + 165);
        }

        private void Mothership_hide()
        {
            Main_Picture.Enabled = false;
            Main_Picture.Image = null;
            Main_Picture.Visible = false;
            Hide_Modules(4);
        }

        private void Show_Planets()
        {
            Main_Picture.Enabled = true;
            Main_Picture.Location = new Point(center.X - Assets[1].Width / 2, center.Y - Assets[1].Height / 2);
            Main_Picture.Size = new Size(Assets[1].Width, Assets[1].Height);
            Main_Picture.Image = Assets[1];
            Main_Picture.Visible = true;
            Show_Modules(ellipses.Count());
        }

        void Get_Planet_Points()
        {
            double t = 0;
            for(int i = 0; i<ellipses.Count();i++)
            {
                if(ellipses[i].angle <=90 && ellipses[i].angle >=-90)
                {
                    t = Math.Atan((ellipses[i].width / 2) * Math.Tan(ellipses[i].angle * Math.PI / 180.0) / (ellipses[i].height / 2));
                }
                else if (ellipses[i].angle < -90 && ellipses[i].angle <= -180)
                {
                    t = Math.Atan((ellipses[i].width / 2) * Math.Tan(ellipses[i].angle * Math.PI / 180.0) / (ellipses[i].height / 2))-Math.PI;
                }
                else
                {
                    t = Math.Atan((ellipses[i].width / 2) * Math.Tan(ellipses[i].angle * Math.PI / 180.0) / (ellipses[i].height / 2))+Math.PI;
                }

                Modules[i].Location = new Point((int)(center.X + (ellipses[i].width / 2) * (float)Math.Cos(t))-(Modules[i].Width/2), (int)(center.Y + (ellipses[i].height / 2) * (float)Math.Sin(t))-(Modules[i].Height/2));
            }
        }
        
        private void Gamestart()
        {
            Mothership_show();
            //Mothership_hide();
            //Generate_next_System();
            //Show_Planets();
            this.Invalidate();
        }

        public void Generate_next_System()
        {
            Mothership_hide();
            CreateEllipses();
            for (int i = 0; i < ellipses.Count(); i++)
            {
                int j = Randomint(2, 4);
                Modules[i].BackColor = Color.Transparent;
                Modules[i].Width = Assets[2].Width;
                Modules[i].Height = Assets[2].Height;
                Modules[i].Image = Assets[j];
            }
            Get_Planet_Points();
            Show_Planets();
            this.Invalidate();
        }

        private void Main_Picture_Click(object sender, EventArgs e)
        {
            if(Main_Picture.Image == Assets[0])
            {

            }
        }

        private void Module1_Click(object sender, EventArgs e)
        {
            if (Main_Picture.Image == Assets[0])
            {
                using (Interface box = new Interface("Hangar"))
                {
                    if (box.ShowDialog() == DialogResult.OK)
                    {
                        if (box.Action == "newsys")
                        {
                            Generate_next_System();
                        }
                    }
                }
            }
            else if(Main_Picture.Image == Assets[1])
            {
                if(Module1.Image == Assets[2]|| Module1.Image == Assets[3])
                {
                    using (Interface box = new Interface("Planet"))
                    {

                    }
                }
                else if(Module1.Image == Assets[3] || Module1.Image == Assets[4])
                {
                    using (Interface box = new Interface("Station"))
                    {

                    }
                }
            }
        }

        private void Module2_Click(object sender, EventArgs e)
        {
            if (Main_Picture.Image == Assets[0])
            {
                using (Interface box = new Interface("Bridge"))
                {
                    if(box.ShowDialog() == DialogResult.OK)
                    {
                        if (box.Action == "newsys")
                        {
                            Generate_next_System();
                        }
                    }
                }
            }
            else if (Main_Picture.Image == Assets[1])
            {
                if (Module2.Image == Assets[2] || Module2.Image == Assets[3])
                {
                    using (Interface box = new Interface("Planet"))
                    {
                        if (box.ShowDialog() == DialogResult.OK)
                        {
                            if (box.Action == "mine")
                            {

                            }
                            else if (box.Action == "explore")
                            {

                            }
                        }
                    }
                }
                else if (Module2.Image == Assets[3] || Module2.Image == Assets[4])
                {
                    using (Interface box = new Interface("Station"))
                    {
                        if (box.ShowDialog() == DialogResult.OK)
                        {
                            if (box.Action == "")
                            {

                            }
                        }
                    }
                }
            }
        }

        private void Module3_Click(object sender, EventArgs e)
        {
            if (Main_Picture.Image ==Assets[0])
            {
                using (Interface box = new Interface("Engineering"))
                {
                    box.ShowDialog();
                }
            }
            else if (Main_Picture.Image == Assets[1])
            {
                if (Module3.Image == Assets[2] || Module3.Image == Assets[3])
                {
                    using (Interface box = new Interface("Planet"))
                    {

                    }
                }
                else if (Module3.Image == Assets[3] || Module3.Image == Assets[4])
                {
                    using (Interface box = new Interface("Station"))
                    {

                    }
                }
            }
        }

        private void Module4_Click(object sender, EventArgs e)
        {
            if (Main_Picture.Image == Assets[0])
            {
                using (Interface box = new Interface("Reactor"))
                {
                    box.ShowDialog();
                }
            }
            else if (Main_Picture.Image == Assets[1])
            {
                if (Module4.Image == Assets[2] || Module4.Image == Assets[3])
                {
                    using (Interface box = new Interface("Planet"))
                    {

                    }
                }
                else if (Module4.Image == Assets[3] || Module4.Image == Assets[4])
                {
                    using (Interface box = new Interface("Station"))
                    {

                    }
                }
            }
        }

        private void Module5_Click(object sender, EventArgs e)
        {
            if (Main_Picture.Image == Assets[0])
            {

            }
            else if (Main_Picture.Image == Assets[1])
            {
                if (Module5.Image == Assets[2] || Module5.Image == Assets[3])
                {
                    using (Interface box = new Interface("Planet"))
                    {

                    }
                }
                else if (Module5.Image == Assets[3] || Module5.Image == Assets[4])
                {
                    using (Interface box = new Interface("Station"))
                    {

                    }
                }
            }
        }

        private void Module6_Click(object sender, EventArgs e)
        {
            if (Main_Picture.Image == Assets[0])
            {

            }
            else if (Main_Picture.Image == Assets[1])
            {
                if (Module6.Image == Assets[2] || Module6.Image == Assets[3])
                {
                    using (Interface box = new Interface("Planet"))
                    {

                    }
                }
                else if (Module6.Image == Assets[3] || Module6.Image == Assets[4])
                {
                    using (Interface box = new Interface("Station"))
                    {

                    }
                }
            }
        }

        private void Module7_Click(object sender, EventArgs e)
        {
            if (Main_Picture.Image == Assets[0])
            {

            }
            else if (Main_Picture.Image == Assets[1])
            {
                if (Module7.Image == Assets[2] || Module7.Image == Assets[3])
                {
                    using (Interface box = new Interface("Planet"))
                    {

                    }
                }
                else if (Module7.Image == Assets[3] || Module7.Image == Assets[4])
                {
                    using (Interface box = new Interface("Station"))
                    {

                    }
                }
            }
        }

        private void Module8_Click(object sender, EventArgs e)
        {
            if (Main_Picture.Image == Assets[0])
            {
                
            }
            else if (Main_Picture.Image == Assets[1])
            {
                if (Module8.Image == Assets[2] || Module8.Image == Assets[3])
                {
                    using (Interface box = new Interface("Planet"))
                    {

                    }
                }
                else if (Module8.Image == Assets[3] || Module8.Image == Assets[4])
                {
                    using (Interface box = new Interface("Station"))
                    {

                    }
                }
            }
        }

        private void txt_Username_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(null,null);
            }
        }

        private void txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(null, null);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if(MessageBox.Show("Exit?", "Do you really wanna quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conon.DBAbgleichClientServer();
                    this.Close();
                }
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if(ellipses.Count() > 0)
            {
                for(int i = 0; i<ellipses.Count(); i++)
                {
                    e.Graphics.DrawEllipse(Grey, center.X-(ellipses[i].width/2), center.Y-(ellipses[i].height/2), ellipses[i].width, ellipses[i].height);
                }
            }
        }
    }
}

