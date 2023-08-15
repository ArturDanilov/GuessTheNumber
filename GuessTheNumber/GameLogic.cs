namespace GuessTheNumber
{
    internal class GameLogic
    {
        private IUserInteractionService _userInteractionService;
        private IHintProvider _hintProvider;
        private GameSettings _settings;

        public GameLogic(GameSettings settings, IUserInteractionService userInput, IHintProvider hintProvider)
        {
            _settings = settings;
            _userInteractionService = userInput;
            _hintProvider = hintProvider;
        }

        public void PlayGame()
        {
            while (_settings.RemainingAttempts > 0)
            {
                _userInteractionService.Try();
                var attemptedNumber = _userInteractionService.GetAttemptedNumber();

                if (_settings.RiddledNumber == attemptedNumber)
                {
                    _userInteractionService.Winner();
                    return;
                }
                else
                {
                    _userInteractionService.FalseGuess(attemptedNumber);

                    if (_settings.WantsHints)
                    {
                        _userInteractionService.OutputMessage(_hintProvider.ProvideHint(_settings.RiddledNumber, attemptedNumber));
                    }

                    _settings.RemainingAttempts--;
                    _userInteractionService.RemainingAttempts(_settings.RemainingAttempts);
                }

                if (_settings.RemainingAttempts == 0)
                {
                    _userInteractionService.Looser(_settings.RiddledNumber);
                }
            }
        }
    }
}
