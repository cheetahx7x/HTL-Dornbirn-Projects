using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _005_SpaceTrade_Shane_Johannes
{
    class ClientDB
    {
        string connetionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Client_Database;User ID=C;Password=abcdefg";
        SqlConnection cnn;
        SqlCommand sqlCmd;
    }
}
