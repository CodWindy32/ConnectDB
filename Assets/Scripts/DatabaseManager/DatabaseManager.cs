using System;
using UnityEngine;
using System.Data.SqlClient;

namespace DatabaseManager
{
    public class DatabaseConnection
    {
        public static SqlConnection ConnectionSql;
        private static string _serverHost = "localhost";
        private static string _database = "MiniHotelDB";

        public static void Connection()
        {
            string connectionString = "Server=" + _serverHost + ";Database=" + _database + ";Integrated Security=True";

            ConnectionSql = new SqlConnection(connectionString);

            try
            {
                ConnectionSql.Open();
            }
            catch (Exception ex)
            {
                Debug.Log("Error connecting to MySQL database: " + ex.Message);
            }
        }
    }
}

