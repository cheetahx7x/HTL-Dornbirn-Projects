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

        private void connect(string database)
        {
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
            }
            catch(Exception e)
            {
                
            }
        }

        private void disconnect()
        {
            cnn.Close();
        }
    }
}
