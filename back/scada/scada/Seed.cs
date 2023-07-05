using scada.Data;
using scada.Models;

namespace scada
{
    public class Seed
    {
        private readonly DataContext _dataContext;
        public Seed(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void SeedDataContext()
        {
            if (!_dataContext.Users.Any())
            {
                AddUsers();

                _dataContext.SaveChanges();
            }
        }

        private void AddUsers()
        {
            var users = new List<User>()
                {
                    new User("admin", "admin", "admin"),
                    new User("user", "user", "user")
                };

            _dataContext.Users.AddRange(users);
        }
    }
}
