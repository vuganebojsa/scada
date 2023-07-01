using scada.Data;
using scada.Interfaces;
using scada.Models;

namespace scada.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) {
        _context = context;}

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(x => x.Id).ToList();
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return _context.Users.Where(x => x.Username==username && x.Password==password).FirstOrDefault();
        }
    }
}