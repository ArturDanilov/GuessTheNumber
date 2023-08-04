namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberGenerator = new FakeNumberGenerator(5);
            var logger = new LoggerToConsole();
            var userInput = new ConsoleUserInput(logger);
            var game = new Game(numberGenerator, logger, userInput);

            game.Start();
        }
    }
}