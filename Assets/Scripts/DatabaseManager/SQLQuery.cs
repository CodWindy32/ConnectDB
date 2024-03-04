using System.Collections.Generic;
using System.Data.SqlClient;

namespace DatabaseManager
{
    public sealed class SqlQuery:DatabaseConnection
    {
        private static string read = "";
        public static string ExecuteQuerySelect(string querySelect, bool manySelect)
        {
            Connection();

            SqlCommand cmd = new SqlCommand(querySelect, ConnectionSql);
            SqlDataReader reader = cmd.ExecuteReader();

            List<string> result = new List<string>();

            while (reader.Read())
            {
                int i = 0;
                
                if (manySelect)
                {
                    read = reader[i].ToString().Replace(" ", "");
                }
                else
                {
                    read = reader[i].ToString();
                }

                result.Add(read);
                i++;
            }

            ConnectionSql.Close();

            return string.Join(";", result);
        }

        public static void ExecuteQueryEditing(string queryEditing)
        {
            Connection();

            SqlCommand cmd = new SqlCommand(queryEditing, ConnectionSql);
            cmd.ExecuteNonQuery();

            ConnectionSql.Close();
        }
    }
}

