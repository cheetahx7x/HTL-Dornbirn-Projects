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
using System.IO;

namespace _001_Ein_Auslesen_SQL_Database
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        string connetionString = null;
        SqlConnection cnn;

        private void login_Load(object sender, EventArgs e)
        {
            txt_name.Text = System.Environment.MachineName;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                connetionString = "Data Source=" + txt_name.Text + ";Initial Catalog=master;User ID=" + txt_login.Text + ";Password=" + txt_pass.Text;
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                if(cnn.State == ConnectionState.Open)
                {
                    Program.servername = txt_name.Text;
                    Program.login = txt_login.Text;
                    Program.password = txt_pass.Text;
                    cnn.Close();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "CRITICAL FAILURE!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            
        }
    }
}
