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

        private void WriteText(string message, List<String> Buttons, int speed)
        {
            if(Buttons.Count() == 2)
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
                    if (txt_inventory.InvokeRequired == true)
                        txt_inventory.Invoke((MethodInvoker)delegate 
                        {
                            txt_inventory.Text = tmp;
                            txt_inventory.LinkArea = new LinkArea(0, 0);
                            if(index == message.Length - 1)
                            {
                                if(Buttons.Count() == 2)
                                {
                                    txt_inventory.Links.Add(message.Length - Buttons[1].Length, Buttons[1].Length);
                                    txt_inventory.Links.Add(message.Length - Buttons[1].Length - Buttons[0].Length - 2, Buttons[0].Length);
                                    txt_inventory.Links[0].Name = "Inventar";
                                    txt_inventory.Links[1].Name = "Reiseziele";
                                }
                            }
                        });

                    else
                        txt_inventory.Text = txt_inventory.Text = tmp;
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

        DBConnection con = new DBConnection("5.9.13.41", "c", "Rvmk9!17", "spacetrade");
        List<String> sButtons = new List<string>();

        private void MainForm_Load(object sender, EventArgs e)
        {
            txt_inventory.Links.Clear();
            sButtons.Add("Inventar");
            sButtons.Add("Reiseziele");
            WriteText("A long time ago in a galaxy far, far away ...", sButtons, 50);
        }

        private void txt_inventory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(e.Link.Name == "Inventar")
            {
                string Text = "Inventar\n\n";

                List<string> Inventory = con.Select("SELECT * FROM Erze", 0);

                foreach(string s in Inventory)
                {
                    Text = Text + s + "\n";
                }

                WriteText(Text, new List<String>(), 1);
            }
        }
    }
}

