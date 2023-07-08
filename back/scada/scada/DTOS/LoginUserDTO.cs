namespace scada.DTOS
{
    public class LoginUserDTO
    {
        public string Username { get; set; }
        public string Role { get; set; }

        public LoginUserDTO(string username, string role)
        {
            Username = username;
            Role = role;
        }
    }
}
