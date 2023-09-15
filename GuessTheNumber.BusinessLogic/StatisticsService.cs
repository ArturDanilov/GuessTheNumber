using GuessTheNumber.DataAccess;

namespace GuessTheNumber.BusinessLogic
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationContext _dbContext;
        private readonly IUserInteractionService _userInteractionService;

        public StatisticsService(ApplicationContext dbContext, IUserInteractionService userInteractionService)
        {
            _dbContext = dbContext;
            _userInteractionService = userInteractionService;
        }

        public async Task SaveGameResultAsync(GameResult gameResult, UserEntity user, GameConfiguration configuration)
        {
            if (configuration.TrackStatistics)
            {
                var gameResultEntity = new GameResultEntity()
                {
                    GameDate = DateTimeOffset.UtcNow,
                    GameWon = gameResult.GameWon,
                    RiddledNumber = gameResult.RiddledNumber,
                    AttemptsTaken = gameResult.AttemptsTaken,
                    TotalAttempts = gameResult.TotalAttempts,
                    HintsEnabled = configuration.WantsHints,
                    UserId = user.Id
                };

                _dbContext.GameResults.Add(gameResultEntity);
                await _dbContext.SaveChangesAsync();
                _userInteractionService.OutputMessage($"\nThe result of the game is saved in the database");
            }
        }
    }
}
