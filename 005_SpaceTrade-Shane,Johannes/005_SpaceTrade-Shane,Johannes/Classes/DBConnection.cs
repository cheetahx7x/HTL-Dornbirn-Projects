using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace _005_SpaceTrade_Shane_Johannes
{
    public class DBConnection
    {
        public String bearbeiter;
        public int bearbeiterID;
        private MySqlConnection connection;
        List<string> tmplist = new List<string>();
        ClientDB Client = new ClientDB();

        public DBConnection(String server, String username, String pw, String db)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = server;
            builder.UserID = username;
            builder.Password = pw;
            builder.Database = db;
            builder.Port = 3306;
            builder.CharacterSet = "utf8";

            connection = new MySqlConnection(builder.ConnectionString);
        }

        public void connect()
        {
            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator", "ERROR",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again", "ERROR",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                        break;
                    default:
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        break;
                }
            }
        }

        public void Update(String query)
        {
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                //Execute command
                cmd.ExecuteNonQuery();
            }
        }

        public List<string> Select(String query, int column)
        {
            tmplist.Clear();
            //Create Command
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tmplist.Add(reader.GetString(column));
                    }
                }
            }
            return tmplist;
        }

        public void disconnect()
        {
            connection.Close();
        }

        public void DBTuningTableClientServer(string tablenameClient, string tablenameServer, int[] ColumnsClient, int[] ColumnsServer)
        {

        }

        public void DBTuningTableServerClient(string tablenameServer, string tablenameClient, int[] ColumnsServer, int[] ColumnsClient)
        {
            List<string> data = new List<string>();
            string Columnname = "";

            bool empty = false;
            bool success = false;

            for (int i = 0; i < ColumnsServer.Length; i++)
            {
                int Count = 0;
                do
                {
                    data = new List<string>();
                    data = Select("SELECT * FROM " + tablenameServer, ColumnsServer[i]);
                    if (data == Select("SELECT * FROM " + tablenameServer, ColumnsServer[i]))
                    {
                        success = true;
                    }
                    Count++;
                } while (success == false && Count < 10);
                if(success == true)
                {
                    success = false;
                }
                else
                {
                    MessageBox.Show("Überprüfen Sie ihre Internetverbindung!", "Datenabgleich fehlgeschlagen!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                Client.connect();
                if (Client.Select("Select * from " + tablenameClient, 0).Count == 0)
                {
                    empty = true;
                }

                Columnname = Client.Select("SELECT column_name FROM information_schema.columns WHERE table_name = '" + tablenameClient + "' and ORDINAL_POSITION = '" + ColumnsClient[i] + "'", 0)[0];

                for (int j = 0; j<data.Count;j++)
                {
                    if(empty == true)
                    {
                        Client.Update("INSERT INTO " + tablenameClient + "(" + Columnname + ") VALUES (\'" + data[j] + "\')");
                    }
                    else
                    {
                        Client.Update("UPDATE " + tablenameClient + " SET " + Columnname + " = '" + data[j] + "\' WHERE ID = " + (j+1));
                    }
                }
                empty = false;

                Client.disconnect();
            }
        }

        public void DBAbgleichServerClientFirst()
        {
            Client.ClearLocalDB();
            DBTuningTableServerClient("Erze", "Erze", new int[2] { 1, 2 }, new int[2] { 2, 3 });
            DBTuningTableServerClient("Materialien", "Materialien", new int[2] { 1, 2 }, new int[2] { 2, 3 });
        }

        public void DBAbgleichServerClient()
        {

        }

        public void DBAbgleichClientServer()
        {

        }

        public void DBTuningServerClient(string username)
        {
            Client.ClearLocalDB();
            DBTuningTableServerClient("Erze", "Erze", new int[2] { 1, 2 }, new int[2] { 2, 3 });
            DBTuningTableServerClient("Materialien", "Materialien", new int[2] { 1, 2 }, new int[2] { 2, 3 });
            DBTuningTableServerClient("Erze_M", "Erze", new int[1] { 2 }, new int[1] { 4 });
            DBTuningTableServerClient("Materialien_M", "Materialien", new int[1] { 2 }, new int[1] { 4 });
        }

        public void DBTuningClientServer(string username)
        {

        }

        public bool DBUserCheck(string username, string pwhash)
        {
            connect();
            Select("SELECT * FROM benutzer WHERE name = '" + username + "' and pw = '" + pwhash + "'", 1);
            disconnect();
            if(tmplist.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
