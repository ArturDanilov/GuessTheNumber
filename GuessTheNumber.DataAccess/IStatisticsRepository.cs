namespace GuessTheNumber.DataAccess
{
    public interface IStatisticsRepository
    {
        Task<List<UserStatistics>> GetTop5PlayersByGameCountAsync();
    }
}