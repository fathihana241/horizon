using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace _12
{
    public class databasehelper
    {
        private string connectionsString;

        public databasehelper(string connectionString)
        {
            this.connectionsString = connectionString;
        }

        public void InsertConference(string conferenceName, string venue, string status, DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(connectionsString))
            {
                string query = "INSERT INTO db_con (ConferenceName, Venue, Status, Date) VALUES (@ConferenceName, @Venue, @Status, @Date)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ConferenceName", conferenceName);
                command.Parameters.AddWithValue("@Venue", venue);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@Date", date);
                connection.Open();
                command.ExecuteNonQuery();

            }
        }
        public DataTable GetAllConferences()
        {
            using (SqlConnection connection = new SqlConnection(connectionsString))
            {
                string query = "SELECT * FROM db_con";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        public bool DeleteConference(string ConferenceName)
        {
            string query = "DELETE FROM db_con WHERE ConferenceName = @ConferenceName";

            using (SqlConnection connection = new SqlConnection(connectionsString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ConferenceName", ConferenceName);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Return true if a row was deleted
                }
                catch (Exception ex)
                {
                    // Log exception or display error message
                    Console.WriteLine($"Error deleting conference: {ex.Message}");
                    return false;
                }
            }
        }


    }
}
