namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberGenerator = new NumberGenerator();
            var userOutput = new ConsoleUserOutput();
            var userInput = new ConsoleUserInput(userOutput);
            var hintProvider = new HintProvider();
            var game = new Game(numberGenerator, userOutput, userInput, hintProvider);

            game.Start();
        }
    }
}