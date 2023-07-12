using scada.Models;

namespace scada.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();

        User GetByUsernameAndPassword(string username, string password);
    }
}