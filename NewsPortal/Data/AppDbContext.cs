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

        // --- DOCUMENTS ---
        public DbSet<CaseDocument> CaseDocuments { get; set; }
        public DbSet<CaseDocumentTranslation> CaseDocumentTranslation { get; set; }

        // --- NOTES ---
        public DbSet<CaseNote> CaseNotes { get; set; }
        public DbSet<CaseNoteTranslation> CaseNoteTranslation { get; set; }

        // --- LAWYERS ---
        public DbSet<Lawyer> Lawyers { get; set; }
        public DbSet<LawyerTranslation> LawyerTranslation { get; set; }

        // --- TAGS ---
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagTranslation> TagTranslation { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CaseDocument
            modelBuilder.Entity<CaseDocumentTranslation>()
                .HasOne(t => t.CaseDocument)
                .WithMany(c => c.Translations)
                .HasForeignKey(t => t.CaseDocumentId);

            // CaseNote
            modelBuilder.Entity<CaseNoteTranslation>()
                .HasOne(t => t.CaseNote)
                .WithMany(n => n.Translations)
                .HasForeignKey(t => t.CaseNoteId);

            // Lawyer
            modelBuilder.Entity<LawyerTranslation>()
                .HasOne(t => t.Lawyer)
                .WithMany(l => l.Translations)
                .HasForeignKey(t => t.LawyerId);

            // Tag
            modelBuilder.Entity<TagTranslation>()
                .HasOne(t => t.Tag)
                .WithMany(l => l.Translations)
                .HasForeignKey(t => t.TagId);

            modelBuilder.Entity<Case>()
                .HasMany(c => c.Translations)
                .WithOne(t => t.Case)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CaseTranslation>()
                .HasOne(t => t.CaseFullDescription)
                .WithOne(d => d.CaseTranslation)
                .HasForeignKey<CaseFullDescription>(d => d.CaseTranslationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
