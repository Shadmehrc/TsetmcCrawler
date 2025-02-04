using Microsoft.EntityFrameworkCore;
using Domain.Models.Models;


namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Symbol> Symbols { get; set; }
    }
}
