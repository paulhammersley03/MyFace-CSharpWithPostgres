using System;
using System.Configuration;
using System.Data;
using Npgsql;

namespace MyFace.DataAccess
{
    public static class ConnectionHelper
    {
        public static IDbConnection CreateSqlConnection()
        {
            return new NpgsqlConnection(ConfigurationManager.ConnectionStrings["MyPostgres"].ConnectionString);
        }
    }
}
