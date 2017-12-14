using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString SqlFunction1()
    {

        connetionString = "Data Source=ServerName;
        Initial Catalog = DatabaseName; User ID = UserName; Password = Password"
        return new SqlString (string.Empty);
    }
}
