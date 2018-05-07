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

        public void openConnection()
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
            MySqlCommand cmd = new MySqlCommand(query, connection);

            //Execute command
            cmd.ExecuteNonQuery();
            
        }

        public List<string> Select(String query, int column)
        {

            //Create a data reader and Execute the command
            List<string> list = new List<string>();
            //Create Command
            openConnection();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(reader.GetString(column));
                }
            }
            close();
            return list;
        }

        public void close()
        {
            connection.Close();
        }

        public void DBAbgleichServerClient()
        {
            ClientDB Client = null;
            List<string> tmplist = new List<string>();
            tmplist = Select("SELECT * FROM Erze", 1);
            if (tmplist == Select("SELECT * FROM Erze", 1))
            {
                Client.connect();
            }
        }
    }
}
