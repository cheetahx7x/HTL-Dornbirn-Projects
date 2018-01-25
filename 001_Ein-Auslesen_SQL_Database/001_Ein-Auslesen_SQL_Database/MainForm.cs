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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        string connetionString = null;
        SqlConnection cnn;
        SqlCommand sqlCmd;
        string sql = null;
        int columns;
        bool file = false;
        string curFile = @"C:\Users\jonyf\source\repos\HTL-Dornbirn-Projects\001_Ein-Auslesen_SQL_Database\001_Ein-Auslesen_SQL_Database\bin\Debug\SQLDaten.csv";

        private void btn_execute_Click(object sender, EventArgs e)
        {
            if(cmb_DB.Text != "")
            {
                if (cmb_DB.Text != "" && txt_sql.Text != "")
                {
                    if (File.Exists(curFile))
                    {
                        file = true;
                    }
                    StreamWriter streamWriter = new StreamWriter("SQLDaten.csv", true, System.Text.Encoding.Unicode);
                    sql = txt_sql.Text;
                    try
                    {
                        connect(cmb_DB.Text);
                        try
                        {
                            columns = 0;
                            sqlCmd = new SqlCommand(sql, cnn);
                            if(file == false)
                            {
                                streamWriter.Write("sep=~");
                                streamWriter.Write(Environment.NewLine);
                            }
                            streamWriter.Write(sql);
                            streamWriter.Write('\n');
                            streamWriter.Write('\n');
                            using (SqlCommand command = sqlCmd)
                            {
                                SqlDataReader reader = command.ExecuteReader();

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    streamWriter.Write(reader.GetName(i));
                                    streamWriter.Write('~');
                                }
                                streamWriter.Write('\n');
                                reader.Close();
                            }
                            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                            while (sqlReader.Read())
                            {
                                for(int i = 0; i<sqlReader.FieldCount;i++)
                                {
                                    if(i != 0)
                                    {
                                        streamWriter.Write('~');
                                    }
                                    streamWriter.Write(sqlReader.GetValue(i));
                                }
                                streamWriter.Write('\n');
                            }
                            sqlReader.Close();
                            sqlCmd.Dispose();
                            streamWriter.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            streamWriter.Close();
                        }
                        disconnect();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Can not open connection ! ");
                        streamWriter.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Sie haben noch keine Abfrage eingegeben!", "FEHLER!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Sie haben noch keine Datenbank ausgewählt!", "FEHLER!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }

        private void load_dbs()
        {
            List<string> list_db = new List<string>();
            try
            {
                connect("master");
                try
                {
                    sqlCmd = new SqlCommand("SELECT name FROM master.dbo.sysdatabases", cnn);
                    SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        list_db.Add((string)sqlReader.GetValue(0));
                    }
                    sqlReader.Close();
                    sqlCmd.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Can't access databases!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Can not open connection ! ");
            }
            for (int i = 0; i < list_db.Count(); i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = list_db[i];
                item.Value = list_db[i];
                cmb_DB.Items.Add(item);
            }
        }

        private void connect(string database)
        {
            connetionString = "Data Source=" + Program.servername + ";Initial Catalog="+database+";User ID=" + Program.login + ";Password=" + Program.password;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
        }

        private void disconnect()
        {
            cnn.Close();
        }

        private void tables()
        {
            List<string> list_tables = new List<string>();
            try
            {
                connect(cmb_DB.Text);
                try
                {
                    sqlCmd = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='"+cmb_DB.Text+"'", cnn);
                    SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        list_tables.Add((string)sqlReader.GetValue(0));
                    }
                    sqlReader.Close();
                    sqlCmd.Dispose();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Can't access tables!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                disconnect();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Can not open connection ! ");
            }
            dgv_tables.Rows.Clear();
            for (int i = 0; i < list_tables.Count(); i++)
            {
                dgv_tables.Rows.Add(list_tables[i]);
            }
        }

        private void cmb_DB_SelectedIndexChanged(object sender, EventArgs e)
        {
            tables();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            load_dbs();
        }
    }
}

