
using Microsoft.Data.SqlClient;

namespace Infrastructure.DataBase
{
    public static class SqlDataBase
    {
        public const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Matheus Marciano\Documents\TESTE.mdf;Integrated Security=True;Connect Timeout=30";

        public static SqlConnection GetSqlConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = CONNECTION_STRING;
            return connection;
        }
    }
}
    