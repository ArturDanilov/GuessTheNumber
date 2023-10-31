using GuessTheNumber.DataAccess;

namespace GuessTheNumber.BusinessLogic
{
    public interface ITopStatisticsService
    {
        Task<List<UserStatistics>> GetTopPlayersAsync();

        Task<UserStatistics> GetPlayerStatisticsByNicknameAsync(string nickname);
    }
}