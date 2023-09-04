using Microsoft.EntityFrameworkCore;

namespace GuessTheNumber.DataAccess
{
    public class ApplicationContext : DbContext
    {
        //Plural GameResults
        public DbSet<GameResultEntity> GameResultEntity { get; set; }

        //Plural Users
        public DbSet<UserEntity> UserEntity { get; set; }

        public ApplicationContext() => Database.EnsureCreated();

        //Migration!!!
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=ADanilov-732\\SQLEXPRESS02;Database=gamestatisticsdb5;Trusted_Connection=True;TrustServerCertificate=True;");

        public UserEntity GetOrCreateUser(string nickname, string? name = null)
        {
            var user = UserEntity.FirstOrDefault(x => x.Nickname == nickname);

            if (user == null && name != null)
            {
                user = new UserEntity
                {
                    Nickname = nickname,
                    Name = name
                };

                UserEntity.Add(user);
                SaveChanges();
            }

            return user;
        }
    }
}
