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
        string connetionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jonyf\\source\\repos\\HTL-Dornbirn-Projects\\005_SpaceTrade-Shane,Johannes\\005_SpaceTrade-Shane,Johannes\\Client_Database.mdf;Integrated Security=True";
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
            sqlCmd = new SqlCommand(query, cnn);

            //Execute command
            sqlCmd.ExecuteNonQuery();
        }

        public List<string> Select(String query, int column)
        {
            //Create a data reader and Execute the command
            List<string> list = new List<string>();
            //Create Command
            sqlCmd = new SqlCommand(query, cnn);
            using (SqlDataReader reader = sqlCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(reader.GetValue(column).ToString());
                }
            }
            return list;
        }

        public void ClearLocalDB()
        {
            connect();
            Update("DELETE FROM Erze;");
            Update("DELETE FROM Materialien;");
            Update("DELETE FROM Captain;");
            Update("DELETE FROM Schiffe;");
            Update("DBCC CHECKIDENT (Erze, RESEED, 0)");
            Update("DBCC CHECKIDENT (Materialien, RESEED, 0)");
            Update("DBCC CHECKIDENT (Captain, RESEED, 0)");
            Update("DBCC CHECKIDENT (Schiffe, RESEED, 0)");
            disconnect();
        }
    }
}
