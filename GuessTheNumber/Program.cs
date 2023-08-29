using GuessTheNumber.DataAccess;
using GuessTheNumber.Database;

namespace GuessTheNumber
{
    internal class Program
    {
        private readonly INumberGenerator _numberGenerator;
        private readonly IUserInteractionService _userInteractionService;
        private readonly IHintProvider _hintProvider;
        private readonly ApplicationContext _dbContext;

        //Dependency Injection
        public Program(INumberGenerator numberGenerator, IUserInteractionService userInteractionService, IHintProvider hintProvider, ApplicationContext dbContext)
        {
            _numberGenerator = numberGenerator;
            _userInteractionService = userInteractionService;
            _hintProvider = hintProvider;
            _dbContext = dbContext;
        }

        //SRP Lets go
        static void Main(string[] args)
        {
            //Building Dependencies
            var numberGenerator = new NumberGenerator();
            var userInteractionService = new ConsoleUserInteractionService();
            var hintProvider = new HintProvider();
            var dbContext = new ApplicationContext();

            //Passing Dependencies to the Constructor
            var program = new Program(numberGenerator, userInteractionService, hintProvider, dbContext);
            program.RunGame();
        }

        public void RunGame()
        {
            var gameConfigurationManager = new GameConfigurationManager(_userInteractionService);
            var configuration = gameConfigurationManager.ConfigureGame();

            var game = new Game(_userInteractionService, _hintProvider, _numberGenerator);
            var gameResult = game.Run(configuration);

            if (configuration.TrackStatistics)
            {
                var gameResultEntity = new GameResultEntity()
                {
                    GameDate = gameResult.GameDate,
                    GameWon = gameResult.GameWon,
                    RiddledNumber = gameResult.RiddledNumber,
                    AttemptsTaken = gameResult.AttemptsTaken,
                    TotalAttempts = gameResult.TotalAttempts,
                    HintsEnabled = configuration.WantsHints
                };

                _dbContext.GameResults.Add(gameResultEntity);
                _dbContext.SaveChanges();
                Console.WriteLine("\nThe result of the game is saved in the database");
            }
        }
    }
}