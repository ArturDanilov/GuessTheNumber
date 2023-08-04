namespace GuessTheNumber
{
    internal class ConsoleUserInput : IUserInput
    {
        private const int MinValue = 1;
        private const int MaxValue = 10;
        private ILogger _logger;

        public ConsoleUserInput(ILogger logger)
        {
            _logger = logger;
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

                _logger.InvalidInput();
                _logger.Try();
            }
        }
    }
}
