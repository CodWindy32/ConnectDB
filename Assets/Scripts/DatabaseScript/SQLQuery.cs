using System.Data.SqlClient;
using UnityEngine;

namespace DBManager
{
    public sealed class SQLQuery:DatabaseManager
    {
        public static void ExecuteQuerySelect(string querySelect)
        {
            Connection();

            SqlCommand cmd = new SqlCommand(querySelect, connectionSQL);
            SqlDataReader reader = cmd.ExecuteReader();
              
            while (reader.Read())
            {
                int i = 0;
                Debug.Log(reader[i].ToString());
                i++;
            }
        
            connectionSQL.Close();
        }

        public static void ExecuteQueryEditing(string queryEditing)
        {
            Connection();

            SqlCommand cmd = new SqlCommand(queryEditing, connectionSQL);
            cmd.ExecuteNonQuery();

            connectionSQL.Close();
        }
    }
}

