namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Welcome to the GuessTheNumber!\n");

            var numberGenerator = new NumberGenerator();
            var logger = new LoggerToConsole();
            var game = new Game(numberGenerator, logger);

            game.TryGame();
        }
    }
}