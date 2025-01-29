using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace _12
{
    public class dbHelper
    {
        private string connectionString = "Data Source=LAPTOP-ARKJQQOS\\SQLEXPRESS01;Initial Catalog=us_pw;Integrated Security=True;";


        public bool AddSession(Sessio session)
        {
            string query = "INSERT INTO db_sess (SessionTitle, Venue, Duration, SessionType, Date, SpeakerName, SpeakerRole, ParticipantsCapacity, SessionStatus) " +
                           "VALUES (@SessionTitle, @Venue, @Duration, @SessionType, @Date, @SpeakerName, @SpeakerRole, @ParticipantsCapacity, @SessionStatus)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Map parameters
                command.Parameters.AddWithValue("@SessionTitle", session.SessionTitle);
                command.Parameters.AddWithValue("@Venue", session.Venue);
                command.Parameters.AddWithValue("@Duration", session.Duration);
                command.Parameters.AddWithValue("@SessionType", session.SessionType);
                command.Parameters.AddWithValue("@Date", session.Date);
                command.Parameters.AddWithValue("@SpeakerName", session.SpeakerName);
                command.Parameters.AddWithValue("@SpeakerRole", session.SpeakerRole);
                command.Parameters.AddWithValue("@ParticipantsCapacity", session.ParticipantsCapacity);
                command.Parameters.AddWithValue("@SessionStatus", session.SessionStatus);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public DataTable GetSessions()
        {
            string query = "SELECT * FROM db_sess";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return dataTable;
        }
        private readonly string ConnectionString = "Data Source=LAPTOP-ARKJQQOS\\SQLEXPRESS01;Initial Catalog=us_pw;Integrated Security=True;Encrypt=False";
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddRange(parameters);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }
        public bool DeleteSession(string SessionTitle)
        {
            string query = "DELETE FROM db_sess WHERE SessionTitle = @SessionTitle";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SessionTitle", SessionTitle);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

    }






}
        
