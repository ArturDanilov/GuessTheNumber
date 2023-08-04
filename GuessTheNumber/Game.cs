namespace GuessTheNumber
{
    internal class Game
    {
        private INumberGenerator _numberGenerator;
        private ILogger _logger;
        private IUserInput _userInput;
        private int _attempts = 3;

        public Game(INumberGenerator numberGenerator, ILogger logger, IUserInput userInput)
        {
            _numberGenerator = numberGenerator;
            _logger = logger;
            _userInput = userInput;
        }

        public void Start()
        {
            int riddledNumber = _numberGenerator.GenerateNumber();
            int remainingAttempts = _attempts;

            for (int i = 0; i < _attempts; i++)
            {
                _logger.Try();
                var attemptedNumber = _userInput.GetAttemptedNumber();


                if (riddledNumber == attemptedNumber)
                {
                    _logger.Winner();
                    return;
                }
                else
                {
                    _logger.FalseGuess(attemptedNumber);
                    _logger.RemainingAttempts(remainingAttempts -= 1);
                }

                if (i == _attempts - 1)
                {
                    _logger.Looser(riddledNumber);
                }
            }
        }
    }
}
