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

namespace _005_SpaceTrade_Shane_Johannes
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private void WriteText(LinkLabel Label, string message, List<String> Buttons, int speed)
        {
            Label.Links.Clear();
            if (Buttons.Count() == 2)
            {
                message = message + "\n\n" + sButtons[0] + "\n\n" + sButtons[1];
            }
            string tmp = "";
            var index = 0;
            var timer = new System.Timers.Timer(speed);
            timer.Elapsed += delegate {
                if (index < message.Length)
                {
                    tmp = tmp + message[index];
                    if (Label.InvokeRequired == true)
                        Label.Invoke((MethodInvoker)delegate 
                        {
                            Label.Text = tmp;
                            Label.LinkArea = new LinkArea(0, 0);
                            if(index == message.Length - 1)
                            {
                                if(Buttons.Count() == 2)
                                {
                                    Label.Links.Add(message.Length - Buttons[1].Length, Buttons[1].Length);
                                    Label.Links.Add(message.Length - Buttons[1].Length - Buttons[0].Length - 2, Buttons[0].Length);
                                    Label.Links[0].Name = "Inventar";
                                    Label.Links[1].Name = "Reiseziele";
                                }
                            }
                        });

                    else
                        Label.Text = Label.Text = tmp;
                    index++;
                }
                else
                {
                    timer.Enabled = false;
                    timer.Dispose();
                }
            };
            timer.Enabled = true;

        }

        private void Inventory()
        {

        }

        DBConnection conon = new DBConnection("5.9.13.41", "c", "Rvmk9!17", "spacetrade");
        

        List<String> sButtons = new List<string>();

        private void MainForm_Load(object sender, EventArgs e)
        {
            sButtons.Add("Inventar");
            sButtons.Add("Reiseziele");
            WriteText(txt_main, "A long time ago in a galaxy far, far away ...", sButtons, 50);
        }

        private void txt_main_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link.Name == "Inventar")
            {
                string Text = "Inventar\n\n";

                List<string> Inventory = conon.Select("SELECT * FROM Erze", 0);

                foreach(string s in Inventory)
                {
                    Text = Text + s + "\n";
                }

                WriteText(txt_inventory, Text, new List<string>(), 1);
            }
        }
    }
}

