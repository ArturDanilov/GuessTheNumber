namespace GuessTheNumber.DataAccess
{
    public interface IStatisticsRepository
    {
        Task<List<UserStatistics>> GetTop5PlayersByGameCountAsync();

        Task<UserStatistics> GetPlayerStatisticsByNicknameAsync(string nickname);
    }
}