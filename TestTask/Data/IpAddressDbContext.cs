using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Data
{
    public class IpAddressDbContext : DbContext
    {
        public IpAddressDbContext(DbContextOptions<IpAddressDbContext> options) : base(options) 
        { 
            Database.EnsureCreated();
        }

        public DbSet<IpAddressInfo> IpAddressInfo { get; set; }
    }
}
