using Microsoft.AspNetCore.Identity;

namespace scada.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public User()
        {
            
        }

        public User(string username, string password, string role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
        }


    }
}
