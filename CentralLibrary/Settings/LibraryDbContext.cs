using CentralLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace CentralLibrary.Settings
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
        {
        }
    }
}
