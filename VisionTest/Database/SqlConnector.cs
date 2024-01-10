using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VisionTest.Database
{
    public  class SqlConnector
    {
        public static SqlConnection? sqlConnection;
        public SqlConnector(string connectionString) 
        {
            sqlConnection = new SqlConnection(connectionString);
        }
    }
}
