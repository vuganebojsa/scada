using System;
namespace scada.DTOS
{
    public class UserDTO
    {

        public string username { get; set; }
        public string password { get; set; }

        public UserDTO()
        {
            
        }

        public UserDTO(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }

}