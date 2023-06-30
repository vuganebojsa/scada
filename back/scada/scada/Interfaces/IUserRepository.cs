using scada.Models;

namespace scada.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
    }
}