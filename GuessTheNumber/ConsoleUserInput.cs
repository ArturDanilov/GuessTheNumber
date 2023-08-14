namespace GuessTheNumber
{
    internal class ConsoleUserInput : IUserInput
    {
        private const int MinValue = 1;
        private const int MaxValue = 10;
        private IUserOutput _userInteractionService;

        public ConsoleUserInput(IUserOutput userOutput)
        {
            _userInteractionService = userOutput;
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
            while (true)
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

        public bool GetYesOrNoAnswer(string prompt)
        {
            while (true)
            {
                _userInteractionService.OutputMessage(prompt);
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
                    _userInteractionService.OutputMessage("Please answer 'yes' or 'no'.");
                }
            }
        }
    }
}
