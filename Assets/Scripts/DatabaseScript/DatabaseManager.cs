using System;
using UnityEngine;
using System.Data.SqlClient;

namespace DBManager
{
    public class DatabaseManager
    {
        public static SqlConnection connectionSQL;
        private static string serverHost = "localhost";
        private static string database = "Shoko";

        public static void Connection()
        {
            string connectionString = "Server=" + serverHost + ";Database=" + database + ";Integrated Security=True";

            connectionSQL = new SqlConnection(connectionString);

            try
            {
                connectionSQL.Open();
            }
            catch (Exception ex)
            {
                Debug.Log("Error connecting to MySQL database: " + ex.Message);
            }
        }
    }
}

