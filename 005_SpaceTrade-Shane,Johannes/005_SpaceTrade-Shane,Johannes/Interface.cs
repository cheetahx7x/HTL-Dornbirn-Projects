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
            btn_next_sys.Enabled = false;
            btn_next_sys.Visible = false;


            if(Type == "Bridge")
            {
                Bridge();
            }
        }

        private void Bridge()
        {
            btn_next_sys.Enabled = true;
            btn_next_sys.Visible = true;
        }

        private void btn_next_sys_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Action = "newsys";
            this.Close();
        }
    }
}
