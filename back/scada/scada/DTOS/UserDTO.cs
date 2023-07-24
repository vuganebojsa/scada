using scada.ErrorHandlers;
using System;
using System.ComponentModel.DataAnnotations;

namespace scada.DTOS
{
    public class UserDTO
    {

        [CustomRequired("Username")]
        [CustomMinLength("Username", 4)]
        public string username { get; set; }

        [CustomRequired("Password")]
        [CustomMinLength("Password", 4)]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z]).{4,}$", ErrorMessage ="Password should have 1 uppercase letter, 1 number and atleast 4 characters.")]
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