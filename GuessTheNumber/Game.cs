namespace GuessTheNumber
{
    internal class Game
    {
        private IUserInteractionService _userInteractionService;
        private IHintProvider _hintProvider;

        public Game(IUserInteractionService userInteractionService, IHintProvider hintProvider)
        {
            _userInteractionService = userInteractionService;
            _hintProvider = hintProvider;
        }

        public void Start(GameConfiguration configuration, INumberGenerator _numberGenerator)
        {
            int _riddledNumber = _numberGenerator.GenerateNumber();

            while (configuration.RemainingAttempts > 0)
            {
                _userInteractionService.Try();
                var attemptedNumber = _userInteractionService.GetAttemptedNumber();

                if (_riddledNumber == attemptedNumber)
                {
                    _userInteractionService.Winner();
                    return;
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

                if (configuration.RemainingAttempts == 0)
                {
                    _userInteractionService.Looser(_riddledNumber);
                }
            }
        }
    }
}
