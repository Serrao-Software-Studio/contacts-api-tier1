using _T1__ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace _T1__ContactsAPI.Data
{
    // Tier 1: The EF Core Context handles the database mapping.
    public class AppDbContext : DbContext
    {
        // Constructor used by Dependency Injection to pass options (configured in Program.cs)
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        // Tier 1: The DbSet for the Contact table/collection
        // DbSet<T> is required for EF Core to track data for the Contact model.
        public DbSet<Contact> Entities { get; set; } = default!;
    }
}