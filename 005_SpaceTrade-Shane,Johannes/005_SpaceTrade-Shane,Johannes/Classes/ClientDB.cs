using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace _005_SpaceTrade_Shane_Johannes
{
    class ClientDB
    {
        string connetionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Client_Database;User ID=C;Password=abcdefg";
        SqlConnection cnn;
        SqlCommand sqlCmd;

        public void connect()
        {
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Shit gone wrong", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public void disconnect()
        {
            cnn.Close();
        }

        public void Update(String query)
        {
            connect();
            sqlCmd = new SqlCommand(query, cnn);

            //Execute command
            sqlCmd.ExecuteNonQuery();
            disconnect();
        }

        public List<string> Select(String query, int column)
        {

            //Create a data reader and Execute the command
            List<string> list = new List<string>();
            //Create Command
            connect();
            sqlCmd = new SqlCommand(query, cnn);
            using (SqlDataReader reader = sqlCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(reader.GetString(column));
                }
            }
            disconnect();
            return list;
        }
    }
}
