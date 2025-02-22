using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace SecurityDemoApp.Controllers
{
    public class LoginController : Controller
    {
        private string _connectionString = "your_connection_string_here";

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Vulnerabilità di SQL Injection
            string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";
            
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                {
                    return Ok("Login Successful");
                }
                else
                {
                    return Unauthorized("Invalid username or password");
                }
            }
        }
    }
}