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

            int totalAttempts = configuration.RemainingAttempts;
            bool gameWon = false;

            while (configuration.RemainingAttempts > 0)
            {
                _userInteractionService.Try();
                var attemptedNumber = _userInteractionService.GetAttemptedNumber();

                if (_riddledNumber == attemptedNumber)
                {
                    _userInteractionService.Winner();
                    configuration.RemainingAttempts--;
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

                    configuration.RemainingAttempts--;
                    _userInteractionService.RemainingAttempts(configuration.RemainingAttempts);
                }
            }

            if (!gameWon)
            {
                _userInteractionService.Looser(_riddledNumber);
            }

            GameResult gameResult = new()
            {
                GameWon = gameWon,
                TotalAttempts = totalAttempts,
                AttemptsTaken = totalAttempts - configuration.RemainingAttempts,
                RiddledNumber = _riddledNumber,
            };

            return gameResult;
        }
    }
}
