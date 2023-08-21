namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dependency initialization
            INumberGenerator numberGenerator = new NumberGenerator();
            IUserInteractionService userInteractionService = new ConsoleUserInteractionService();
            IHintProvider hintProvider = new HintProvider();

            //game customization
            GameConfigurationManager gameConfigurationManager = new GameConfigurationManager(userInteractionService);
            GameConfiguration configuration = gameConfigurationManager.ConfigureGame();

            //Controlling the game logic
            Game game = new Game(userInteractionService, hintProvider, numberGenerator);
                        
            var gameResult = game.Run(configuration);

            //output statistics result
            if (configuration.TrackStatistics)
            {
                Console.WriteLine("\n\n---- Game Statistics ----");
                Console.WriteLine($"Game Won: {gameResult.GameWon}");
                Console.WriteLine($"Total Attempts: {gameResult.TotalAttempts}");
                Console.WriteLine($"Attempts Taken: {gameResult.AttemptsTaken}");
                Console.WriteLine($"Riddled Number: {gameResult.RiddledNumber}");
                Console.WriteLine("-------------------------");
            }
        }
    }
}