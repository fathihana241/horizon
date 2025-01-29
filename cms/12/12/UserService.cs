using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12
{
    public class UserService
    {
        private readonly dbHelper DBHelper = new dbHelper();


        public bool ValidateUser(string username, string password, string userType, out string message)
        {
            string query = "SELECT * FROM db_login WHERE username = @username AND password = @password AND usertype = @usertype";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password),
                new SqlParameter("@usertype", userType)
            };

            DataTable dt = DBHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                message = $"You are logged in as {userType}";
                return true;
            }


            message = "Invalid username, password, or user type.";
            return false;
        }
    }
}

