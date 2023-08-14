namespace GuessTheNumber
{
    internal class ConsoleUserOutput : IUserOutput
    {
        public void Try() => Console.Write("\nEnter the number: ");

        public void Winner() => Console.WriteLine("\nYou win!");

        public void Looser(int attempts) => Console.Write("\nYou loose! The hidden number was: " + attempts);

        public void InvalidInput() => Console.Write("\nInvalid input, please enter a number between 1 and 10.\n");

        public void FalseGuess(int attepts) => Console.Write(attepts + " is a false guess. ");

        public void RemainingAttempts(int count) => Console.Write("Remaining attempts " + count + ".\n");

        public string AskQuestion(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }

        public void OutputMessage(string message) => Console.Write(message);
    }
}
