using GuessTheNumber.BusinessLogic;
using GuessTheNumber.DataAccess;

namespace GuessTheNumber.Console
{
    public class Program
    {
        private readonly INumberGenerator _numberGenerator;
        private readonly IUserInteractionService _userInteractionService;
        private readonly IHintProvider _hintProvider;
        private readonly ApplicationContext _dbContext;
        private readonly IAuthentication _authentication;

        //Dependency Injection
        public Program(INumberGenerator numberGenerator, IUserInteractionService userInteractionService, IHintProvider hintProvider, ApplicationContext dbContext, IAuthentication authentication)
        {
            _numberGenerator = numberGenerator;
            _userInteractionService = userInteractionService;
            _hintProvider = hintProvider;
            _dbContext = dbContext;
            _authentication = authentication;
        }

        //SRP
        static async Task Main(string[] args)
        {
            //Building Dependencies
            var numberGenerator = new NumberGenerator();
            var userInteractionService = new ConsoleUserInteractionService();
            var hintProvider = new HintProvider();
            var dbContext = new ApplicationContext();
            var authentication = new Authentication(dbContext);

            //Passing Dependencies to the Constructor
            var program = new Program(numberGenerator, userInteractionService, hintProvider, dbContext, authentication);
            await program.RunGameAsync();
        }

        // void => Task
        // object => Task<object>
        public async Task RunGameAsync()
        {
            _authentication.Authorization();

            var gameConfigurationManager = new GameConfigurationManager(_userInteractionService);
            var configuration = gameConfigurationManager.ConfigureGame();

            var game = new Game(_userInteractionService, _hintProvider, _numberGenerator);
            var gameResult = game.Run(configuration);

            if (configuration.TrackStatistics)
            {
                var gameResultEntity = new GameResultEntity()
                {
                    GameDate = DateTimeOffset.UtcNow,
                    GameWon = gameResult.GameWon,
                    RiddledNumber = gameResult.RiddledNumber,
                    AttemptsTaken = gameResult.AttemptsTaken,
                    TotalAttempts = gameResult.TotalAttempts,
                    HintsEnabled = configuration.WantsHints
                };

                _dbContext.GameResultEntity.Add(gameResultEntity);
                _dbContext.SaveChanges();
                System.Console.WriteLine("\nThe result of the game is saved in the database");
            }
        }
    }
}