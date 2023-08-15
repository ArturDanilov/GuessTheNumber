namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            INumberGenerator numberGenerator = new NumberGenerator();
            IUserInteractionService userInput = new ConsoleUserInput();
            IHintProvider hintProvider = new HintProvider();

            GameConfigurationManager gameConfigurationManager = new GameConfigurationManager(numberGenerator, userInput);
            GameSettings settings = gameConfigurationManager.ConfigureGame();
            GameLogic gameLogic = new GameLogic(settings, userInput, hintProvider);

            gameLogic.PlayGame();
        }
    }
}