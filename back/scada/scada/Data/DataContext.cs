using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using scada.Models;

namespace scada.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
    
        }
        public DbSet<User> Users { get; set; }
    }
}
