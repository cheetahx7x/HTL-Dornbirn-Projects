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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            txt_Username.Location = new Point(this.Width / 2 - txt_Username.Width / 2, this.Height / 2 - txt_Username.Height / 2);
            txt_Password.Location = new Point(this.Width / 2 - txt_Password.Width / 2, this.Height / 2 + txt_Password.Height / 2);
            btn_Login.Location = new Point(this.Width / 2 - btn_Login.Width / 2, this.Height / 2 + 2 * txt_Password.Height);
            txt_Fehler.Location = new Point(txt_Username.Location.X + txt_Username.Width + 10, txt_Username.Location.Y + txt_Username.Height / 2);
        }





        DBConnection conon = new DBConnection("5.9.13.41", "c", "Rvmk9!17", "spacetrade");
        ClientDB conof = new ClientDB();
        List<Linkclick> Links = new List<Linkclick>();
        Linkclick tmpLink = new Linkclick();






        private void MainForm_Load(object sender, EventArgs e)
        {
            
            string Text = "Du hast noch keinen Account? Registrieren";
            Add_Link("Registrieren", Text.Length - "Registrieren".Length, Text.Length);
            WriteText(txt_main, Text, Links, 1);
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
                    btn_Login.Dispose();
                    txt_main.Text = "";
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
                            btn_Login.Dispose();
                            txt_main.Text = "";
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
    }
}

