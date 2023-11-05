using System;
using System.Data;
using System.Data.SqlClient;

namespace ADONETtask.Data
{
	internal class AzureSql
    {
        private const string _connectionString = "Server=localhost;Database=MusicArtist;User Id=SA;Password=S@mama123;trusted_connection=false;";
        private static SqlConnection _connection = new SqlConnection(_connectionString);


        public int ExecuteCommand(string cmd)
        {
            int result = 0;
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand(cmd, _connection);
                result = command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _connection.Close();
            }
            return result;

        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();
            try
            {
                _connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
                adapter.Fill(table);

            }
            catch (Exception e)
            {
                throw e;
            } 
            {
                _connection.Close();
            }

            return table;

        }

    }
}

