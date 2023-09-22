using GuessTheNumber.DataAccess;

namespace GuessTheNumber.BusinessLogic
{
    public class TopStatisticsService
    {
        //private readonly ApplicationContext _dbContext;
        private readonly StatisticsRepository _statisticsRepository;

        public TopStatisticsService(ApplicationContext dbContext, StatisticsRepository statisticsRepository)
        {
            //_dbContext = dbContext;
            _statisticsRepository = statisticsRepository;
        }

        public IEnumerable<UserStatistics> GetTopPlayers()
        {
            return _statisticsRepository.GetTop5PlayersByGameCount().ToList();
        }
    }
}
