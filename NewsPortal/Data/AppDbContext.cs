using Microsoft.EntityFrameworkCore;
using NewsPortal.Models;

namespace NewsPortal.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Case> Cases { get; set; }
        public DbSet<WhoWeArePage> WhoWeArePages { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
