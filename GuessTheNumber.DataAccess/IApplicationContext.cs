using Microsoft.EntityFrameworkCore;

namespace GuessTheNumber.DataAccess
{
    public interface IApplicationContext
    {
        DbSet<GameResultEntity> GameResults { get; set; }
        DbSet<UserEntity> Users { get; set; }
    }
}