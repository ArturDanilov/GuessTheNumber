namespace GuessTheNumber
{
    internal class ConsoleUserInteractionService : IUserInteractionService
    {
        private const int MinValue = 1;
        private const int MaxValue = 10;

        public int GetAttemptedNumber()
        {
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out var attemptedNumber))
                {
                    if (attemptedNumber >= MinValue && attemptedNumber <= MaxValue)
                    {
                        return attemptedNumber;
                    }
                }

                InvalidInput();
                Try();
            }
        }

        //TODO Delete double method
        public int GetNumberOfAttempts()
        {
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out var numberOfAttempts))
                {
                    if (numberOfAttempts >= 1)
                    {
                        return numberOfAttempts;
                    }

                    InvalidInput();
                }
            }
        }

        public bool GetYesOrNoAnswer(string prompt)
        {
            while (true)
            {
                OutputMessage(prompt);
                string response = Console.ReadLine().ToLower();

                if (response == "yes")
                {
                    return true;
                }
                else if (response == "no")
                {
                    return false;
                }
                else
                {
                    OutputMessage("Please answer 'yes' or 'no'.");
                }
            }
        }
        public string AskQuestion(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }

        public void Try() => Console.Write("\nEnter the number: ");

        public void Winner() => Console.Write("\nYou win!");

        public void Looser(int attempts) => Console.Write("\nYou loose! The hidden number was: " + attempts);

        public void InvalidInput() => Console.Write("\nInvalid input, please enter a number between 1 and 10.\n");

        public void FalseGuess(int attepts) => Console.Write(attepts + " is a false guess. ");

        public void RemainingAttempts(int count) => Console.Write("Remaining attempts " + count + ".\n");

        public void OutputMessage(string message) => Console.Write(message);
    }
}
