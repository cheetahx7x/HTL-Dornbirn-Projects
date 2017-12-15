﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
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

        private void btn_execute_Click(object sender, EventArgs e)
        {
            if(cmb_DB.Text != "")
            {
                if (cmb_DB.Text != "" && txt_sql.Text != "")
                {
                    StreamWriter streamWriter = new StreamWriter("SQLDaten.csv", true);
                    sql = txt_sql.Text;
                    try
                    {
                        connect(cmb_DB.Text);
                        try
                        {
                            sqlCmd = new SqlCommand(sql, cnn);
                            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                            while (sqlReader.Read())
                            {
                                streamWriter.Write(sqlReader.GetValue(0));
                                streamWriter.Write(',');
                                streamWriter.Write(sqlReader.GetValue(1));
                                streamWriter.Write(',');
                                streamWriter.Write(sqlReader.GetValue(2));
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

        private void Form1_Load(object sender, EventArgs e)
        {
            load_dbs();
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
            connetionString = "Data Source=JOHANNESLAPTOP;Initial Catalog="+database+";User ID=c#;Password=abcdefg";
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

        private void btn_tables_Click(object sender, EventArgs e)
        {
            tables();
        }
    }
}

