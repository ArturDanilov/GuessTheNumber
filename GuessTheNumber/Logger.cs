namespace GuessTheNumber
{
    internal class Logger
    {
        public void Try() => Console.WriteLine("\nEnter the number...");

        public void Winner() => Console.WriteLine("\nYou winn!!!");

        public void Looser() => Console.WriteLine("\nYou loose!!!");

        public void NumberGuessed() => Console.WriteLine("\nNumber guessed...");

        public void InvalidInput() => Console.WriteLine("\nInvalid input, please enter a number between 1 and 10.");

        public void FalseGuess() => Console.WriteLine("False guess.");
    }
}
