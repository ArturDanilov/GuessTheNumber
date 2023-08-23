using Microsoft.EntityFrameworkCore;

namespace GuessTheNumber.Database
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<GameResult> GameResults { get; set; }

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=ADanilov-732\\SQLEXPRESS02;Database=gamestatisticsdb;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
