namespace GuessTheNumber
{
    internal class ConsoleUserInput : IUserInput
    {
        private const int MinValue = 1;
        private const int MaxValue = 10;
        private IUserInteractionService _userInteractionService;

        public ConsoleUserInput(IUserInteractionService logger)
        {
            _userInteractionService = logger;
        }
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

                _userInteractionService.InvalidInput();
                _userInteractionService.Try();
            }
        }

        public int GetNumberOfAttempts()
        {
            while(true)
            {
                if (Int32.TryParse(Console.ReadLine(), out var numberOfAttempts))
                {
                    if (numberOfAttempts >= 1)
                    {
                        return numberOfAttempts;
                    }

                    _userInteractionService.InvalidInput();
                }
            }
        }
    }
}
