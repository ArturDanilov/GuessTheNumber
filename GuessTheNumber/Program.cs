namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberGenerator = new NumberGenerator();
            var logger = new ConsoleUserInterface();
            var userInput = new ConsoleUserInput(logger);
            var hintProvider = new HintProvider();
            var game = new Game(numberGenerator, logger, userInput, hintProvider);

            game.Start();
        }
    }
}