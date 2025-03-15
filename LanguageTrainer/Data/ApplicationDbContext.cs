using LanguageTrainer.Models;
using Microsoft.EntityFrameworkCore;

namespace LanguageTrainer.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; init; }
        public DbSet<Category> Categories { get; init; }
        public DbSet<Word> Words { get; init; }
        public DbSet<WordCategory> WordCategories { get; init; }
        public DbSet<WordDifficulty> WordDifficulties { get; init; }
        public DbSet<UserWord> UserWords { get; init; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<WordCategory>()
                .HasKey(wc => new { wc.WordId, wc.CategoryId });
            modelBuilder.Entity<WordCategory>()
                .HasOne(wc => wc.Word)
                .WithMany(w => w.WordCategories)
                .HasForeignKey(wc => wc.WordId);
            modelBuilder.Entity<WordCategory>()
                .HasOne(wc => wc.Category)
                .WithMany(c => c.WordCategories)
                .HasForeignKey(wc => wc.CategoryId);


            modelBuilder.Entity<UserWord>()
                .HasKey(uw => new { uw.UserId, uw.WordId });
            modelBuilder.Entity<UserWord>()
                .HasOne(uw => uw.User)
                .WithMany(u => u.UserWords)
                .HasForeignKey(uw => uw.UserId);
            modelBuilder.Entity<UserWord>()
                .HasOne(uw => uw.Word)
                .WithMany(w => w.UserWords)
                .HasForeignKey(uw => uw.WordId);


            modelBuilder.Entity<WordDifficulty>()
                .HasOne(wd => wd.Word)
                .WithMany(w => w.WordDifficulties)
                .HasForeignKey(wd => wd.WordId);
        }
    }
}
