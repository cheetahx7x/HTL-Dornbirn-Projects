using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void WriteText(string message, List<String> Buttons)
        {
            if(sButtons.Count() == 2)
            {
                message = message + "\n\n" + sButtons[0] + "\n\n" + sButtons[1];
            }
            string tmp = "";
            var index = 0;
            var timer = new System.Timers.Timer(50);
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
                                txt_inventory.Links.Add(message.Length - Buttons[1].Length, Buttons[1].Length);
                                txt_inventory.Links.Add(message.Length - Buttons[1].Length - Buttons[0].Length - 2, Buttons[0].Length);
                                txt_inventory.Links[0].Name = "Inventar";
                                txt_inventory.Links[1].Name = "Reiseziele";
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

        List<String> sButtons = new List<string>();

        private void MainForm_Load(object sender, EventArgs e)
        {
            txt_inventory.Links.Clear();
            sButtons.Add("Inventar");
            sButtons.Add("Reiseziele");
            WriteText("Hallo das ist ein Test!", sButtons);
        }

        private void txt_inventory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txt_inventory.Text = e.Link.Name;
        }
    }
}

