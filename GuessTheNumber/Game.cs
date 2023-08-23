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
            DateTime date = DateTime.UtcNow;
            bool gameWon = false;
            int totalAttempts = configuration.AttemptsCount;
            int remainingAttempts = configuration.AttemptsCount;
            int riddledNumber = _numberGenerator.GenerateNumber();
            bool hintsEnabled = configuration.WantsHints;

            while (remainingAttempts > 0)
            {
                _userInteractionService.Try();
                var attemptedNumber = _userInteractionService.GetAttemptedNumber();

                if (riddledNumber == attemptedNumber)
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
                        _userInteractionService.OutputMessage(_hintProvider.ProvideHint(riddledNumber, attemptedNumber));
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
                _userInteractionService.Looser(riddledNumber);
            }

            return new()
            {
                GameDate = date,
                GameWon = gameWon,
                TotalAttempts = totalAttempts,
                AttemptsTaken = totalAttempts - remainingAttempts,
                RiddledNumber = riddledNumber,
                HintsEnabled = hintsEnabled
            };
        }
    }
}
