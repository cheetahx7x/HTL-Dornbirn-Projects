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

        private void WriteText(string message)
        {
            string tmp = "";
            var index = 0;
            var timer = new System.Timers.Timer(50);
            timer.Elapsed += delegate {
                if (index < message.Length)
                {
                    tmp = tmp + message[index];
                    if (txt_inventory.InvokeRequired == true)
                        txt_inventory.Invoke((MethodInvoker)delegate { txt_inventory.Text = tmp; });

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

        private void MainForm_Load(object sender, EventArgs e)
        {
            WriteText("asökfgjhaöwoirghöaowjsdöfgoijhawleuhgrödiushaöldkgjfhlseiuhdfglkjhlaskjdgfhöaoeuhföaodufhgöowEBFGÖOAEHGÖFUOAHSÖOGFDIUHAÖSOIGFHÖAODIFGHÖOIHdfldksjfhliehjgf");
        }


    }
}
