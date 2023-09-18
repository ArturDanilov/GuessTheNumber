using Microsoft.EntityFrameworkCore;

namespace GuessTheNumber.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<GameResultEntity> GameResults { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=ADanilov-732\\SQLEXPRESS02;Database=GuessTheNumber;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameResultEntity>()
                .HasOne(gr => gr.User)
                .WithMany()
                .HasForeignKey(gr => gr.UserId);

            modelBuilder.Entity<UserEntity>()
                .Property(gr => gr.Nickname)
                .HasMaxLength(20);
        }
    }
}
