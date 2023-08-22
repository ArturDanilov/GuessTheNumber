namespace GuessTheNumber
{
    internal class Game
    {
        private IUserInteractionService _userInteractionService;
        private IHintProvider _hintProvider;
        private INumberGenerator _numberGenerator;

        public Game(IUserInteractionService userInteractionService, IHintProvider hintProvider, INumberGenerator numberGenerator)
        {
            _userInteractionService = userInteractionService;
            _hintProvider = hintProvider;
            _numberGenerator = numberGenerator;
        }

        public GameResult Run(GameConfiguration configuration)
        {
            int _riddledNumber = _numberGenerator.GenerateNumber();
            int totalAttempts = configuration.AttemptsCount;
            int remainingAttempts = configuration.AttemptsCount;
            bool gameWon = false;

            while (remainingAttempts > 0)
            {
                _userInteractionService.Try();
                var attemptedNumber = _userInteractionService.GetAttemptedNumber();

                if (_riddledNumber == attemptedNumber)
                {
                    remainingAttempts--;
                    gameWon = true;

                    break;
                }
                else
                {
                    _userInteractionService.FalseGuess(attemptedNumber);

                    if (configuration.WantsHints)
                    {
                        _userInteractionService.OutputMessage(_hintProvider.ProvideHint(_riddledNumber, attemptedNumber));
                    }

                    remainingAttempts--;
                    _userInteractionService.RemainingAttempts(remainingAttempts);
                }
            }

            if (gameWon)
            {
                _userInteractionService.Winner();
            }
            else
            {
                _userInteractionService.Looser(_riddledNumber);
            }

            return new()
            {
                GameWon = gameWon,
                TotalAttempts = totalAttempts,
                AttemptsTaken = totalAttempts - remainingAttempts,
                RiddledNumber = _riddledNumber,
            };
        }
    }
}
