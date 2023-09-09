using GuessTheNumber.BusinessLogic;
using GuessTheNumber.DataAccess; //remove

namespace GuessTheNumber.Console
{
    public class Program
    {
        private readonly INumberGenerator _numberGenerator;
        private readonly IUserInteractionService _userInteractionService;
        private readonly IHintProvider _hintProvider;
        private readonly ApplicationContext _dbContext;
        private readonly IUserService _authentication;
        private readonly IStatisticsService _statisticsService;

        public Program(
            INumberGenerator numberGenerator, 
            IUserInteractionService userInteractionService, 
            IHintProvider hintProvider, 
            ApplicationContext dbContext, 
            IUserService authentication,
            IStatisticsService statisticsService)
        {
            _numberGenerator = numberGenerator;
            _userInteractionService = userInteractionService;
            _hintProvider = hintProvider;
            _dbContext = dbContext;
            _authentication = authentication;
            _statisticsService = statisticsService;
        }

        static async Task Main(string[] args)
        {
            var numberGenerator = new NumberGenerator();
            var userInteractionService = new ConsoleUserInteractionService();
            var hintProvider = new HintProvider();
            var dbContext = new ApplicationContext();
            var authentication = new UserService(dbContext);
            var statisticsService = new StatisticsService(dbContext, userInteractionService);

            var program = new Program(
                numberGenerator, 
                userInteractionService, 
                hintProvider, 
                dbContext, 
                authentication,
                statisticsService);
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
                _userInteractionService.OutputMessage($"Welcome back, {user.Name}! ");
            }

            var gameConfigurationManager = new GameConfigurationServis(_userInteractionService);
            var configuration = gameConfigurationManager.ConfigureGame();

            var game = new Game(_userInteractionService, _hintProvider, _numberGenerator);
            var gameResult = game.Run(configuration);

            await _statisticsService.SaveGameResultAsync(gameResult, user, configuration);
        }
    }
}