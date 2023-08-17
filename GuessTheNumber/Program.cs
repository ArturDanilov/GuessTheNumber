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
            
            game.Start(configuration);
        }
    }
}