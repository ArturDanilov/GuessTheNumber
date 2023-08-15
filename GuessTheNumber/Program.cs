namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dependency initialization
            INumberGenerator numberGenerator = new NumberGenerator();
            IUserInteractionService userInput = new ConsoleUserInput();
            IHintProvider hintProvider = new HintProvider();

            //game customization
            GameConfigurationManager gameConfigurationManager = new GameConfigurationManager(numberGenerator, userInput);
            PrepareConfiguration configuration = gameConfigurationManager.ConfigureGame();

            //Controlling the game logic
            GameplayController game = new GameplayController(configuration, userInput, hintProvider);

            game.PlayGame();
        }
    }
}