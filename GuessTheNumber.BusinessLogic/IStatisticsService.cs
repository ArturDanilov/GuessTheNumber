using GuessTheNumber.DataAccess;

namespace GuessTheNumber.BusinessLogic
{
    public interface IStatisticsService
    {
        Task SaveGameResultAsync(GameResult gameResult, UserEntity user, GameConfiguration configuration);
    }
}
