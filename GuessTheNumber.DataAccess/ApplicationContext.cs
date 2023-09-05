using Microsoft.EntityFrameworkCore;

namespace GuessTheNumber.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<GameResultEntity> GameResults { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public ApplicationContext() => Database.EnsureCreatedAsync();

        //TODO Secret
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=ADanilov-732\\SQLEXPRESS02;Database=gamestatisticsdb;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
