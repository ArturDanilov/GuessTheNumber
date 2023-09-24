using GuessTheNumber.DataAccess;

namespace GuessTheNumber.BusinessLogic
{
    public class TopStatisticsService : ITopStatisticsService
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public TopStatisticsService(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<List<UserStatistics>> GetTopPlayersAsync()
        {
            return await _statisticsRepository.GetTop5PlayersByGameCountAsync();
        }
    }
}
