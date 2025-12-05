using Microsoft.EntityFrameworkCore;
using NewsPortal.Models;

namespace NewsPortal.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Case> Cases { get; set; }
        public DbSet<WhoWeArePage> WhoWeArePages { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }

        public DbSet<CallToActionBlock> CallToActionBlocks { get; set; }
        public DbSet<CaseDocument> CaseDocuments { get; set; }
        public DbSet<Lawyer> Lawyers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<CaseNote> CaseNotes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }

}
