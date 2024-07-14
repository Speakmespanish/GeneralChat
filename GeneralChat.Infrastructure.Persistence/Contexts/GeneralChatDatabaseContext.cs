using GeneralChat.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeneralChat.Infrastructure.Persistence.Contexts
{
    public class GeneralChatDatabaseContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Comment> Comment { get; set; }

        public GeneralChatDatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(model =>
            {
                model.ToTable("User");
                model.HasKey(k => k.ID);

                model.Property(p => p.Name).IsRequired().HasMaxLength(75);
                model.Property(p => p.Email).IsRequired().HasMaxLength(128);
                model.Property(p => p.Password).IsRequired().HasMaxLength(512);

                model.HasMany(fk => fk.Comments)
                    .WithOne(fk => fk.User)
                    .HasForeignKey(f => f.UserID).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Comment>(model =>
            {
                model.ToTable("Comment");
                model.HasKey(k => k.ID);

                model.Property(p => p.Content).IsRequired().HasMaxLength(1024);
                model.Property(p => p.SentMessageDate).HasColumnType("DATETIME");

                model.HasOne(fk => fk.User)
                    .WithMany(fk => fk.Comments)
                    .HasForeignKey(f => f.UserID).OnDelete(DeleteBehavior.NoAction);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
