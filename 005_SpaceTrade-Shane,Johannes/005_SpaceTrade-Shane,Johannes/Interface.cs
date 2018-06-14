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
    public partial class Interface : Form
    {
        public Interface(string type)
        {
            InitializeComponent();
            Type = type;
        }

        public string Action { get; set; }
        string Type;

        private void Interface_Load(object sender, EventArgs e)
        {
            btn_1.Enabled = false;
            btn_1.Visible = false;

            if(Type == "Bridge")
            {
                Bridge();
            }

            if(Type == "Planet")
            {
                Planet();
            }
        }

        private void Bridge()
        {
            this.BackgroundImage = _005_SpaceTrade_Shane_Johannes.Properties.Resources.mission_control;
            btn_1.Text = "Start Resource gathering!";
            btn_1.Enabled = true;
            btn_1.Visible = true;
        }

        private void Planet()
        {

        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            if(Type == "Bridge")
            {
                this.DialogResult = DialogResult.OK;
                Action = "newsys";
                this.Close();
            }
        }
    }
}
