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

namespace _001_Ein_Auslesen_SQL_Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_execute_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection cnn;
            string sql = null;
            SqlCommand sqlCmd;
            connetionString = "Data Source=JOHANNESLAPTOP;Initial Catalog=dbWawi;User ID=c#;Password=abcdefg";
            cnn = new SqlConnection(connetionString);
            sql = "select * from dbo.tblPersonal";
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open ! ");
                try
                {
                    sqlCmd = new SqlCommand(sql, cnn);
                    SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        dgv_Personal.Rows.Add(sqlReader.GetValue(0), sqlReader.GetValue(1), sqlReader.GetValue(2));
                        //MessageBox.Show(sqlReader.GetValue(0) + " - " + sqlReader.GetValue(1) + " - " + sqlReader.GetValue(2));
                    }
                    sqlReader.Close();
                    sqlCmd.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not open connection ! ");
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }
    }
}

