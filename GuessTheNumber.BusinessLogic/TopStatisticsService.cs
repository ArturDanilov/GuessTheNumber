using GuessTheNumber.DataAccess;

namespace GuessTheNumber.BusinessLogic
{
    public class TopStatisticsService
    {
        private readonly StatisticsRepository _statisticsRepository;

        public TopStatisticsService(StatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<List<UserStatistics>> GetTopPlayersAsync()
        {
            return await _statisticsRepository.GetTop5PlayersByGameCountAsync();
        }
    }
}
