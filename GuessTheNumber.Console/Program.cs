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
        private readonly IUserService _authentication;

        public Program(INumberGenerator numberGenerator, IUserInteractionService userInteractionService, IHintProvider hintProvider, ApplicationContext dbContext, IUserService authentication)
        {
            _numberGenerator = numberGenerator;
            _userInteractionService = userInteractionService;
            _hintProvider = hintProvider;
            _dbContext = dbContext;
            _authentication = authentication;
        }

        static async Task Main(string[] args)
        {
            var numberGenerator = new NumberGenerator();
            var userInteractionService = new ConsoleUserInteractionService();
            var hintProvider = new HintProvider();
            var dbContext = new ApplicationContext();
            var authentication = new UserService(dbContext);

            var program = new Program(numberGenerator, userInteractionService, hintProvider, dbContext, authentication);
            await program.RunGameAsync();
        }

        public async Task RunGameAsync()
        {
            string nickname = _userInteractionService.GetNickname();
            UserEntity user = await _authentication.CheckUserAsync(nickname);

            if (user == null)
            {
                string name = _userInteractionService.GetName();
                user = await _authentication.CreateUserAsync(nickname, name);
            }
            else
            {
                _userInteractionService.OutputMessage($"Welcome back, {user.Nickname}! ");
            }

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

                _dbContext.GameResults.Add(gameResultEntity);
                await _dbContext.SaveChangesAsync();
                _userInteractionService.OutputMessage($"\nThe result of the game is saved in the database");
            }
        }
    }
}