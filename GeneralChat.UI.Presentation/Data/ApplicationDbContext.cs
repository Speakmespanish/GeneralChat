using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GeneralChat.UI.Presentation.Models;

namespace GeneralChat.UI.Presentation.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ChatMessage> ChatMessages { get; set; } // DbSet para CHATmessage

        // No es necesario DbSet<ApplicationUser> ya que IdentityDbContext ya lo maneja

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aquí puedes configurar restricciones, relaciones, etc.
            // Por ejemplo:
            modelBuilder.Entity<ChatMessage>()
                .HasKey(c => c.ID);
            modelBuilder.Entity<ChatMessage>()
                .Property(c => c.FECHA_HORA)
                .IsRequired();
            modelBuilder.Entity<ChatMessage>()
                .Property(c => c.USUARIO)
                .HasMaxLength(50);
            modelBuilder.Entity<ChatMessage>()
               .Property(c => c.MENSAJE)
               .HasMaxLength(200); // Mensaje tiene una longitud máxima de 200 caracteres

            // Y así sucesivamente para las configuraciones específicas de tu modelo
        }
    }
}
