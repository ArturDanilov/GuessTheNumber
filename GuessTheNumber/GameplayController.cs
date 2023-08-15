namespace GuessTheNumber
{
    internal class GameplayController
    {
        private IUserInteractionService _userInteractionService;
        private IHintProvider _hintProvider;
        private PrepareConfiguration _configuration;

        public GameplayController(PrepareConfiguration configuration, IUserInteractionService userInput, IHintProvider hintProvider)
        {
            _configuration = configuration;
            _userInteractionService = userInput;
            _hintProvider = hintProvider;
        }

        public void PlayGame()
        {
            while (_configuration.RemainingAttempts > 0)
            {
                _userInteractionService.Try();
                var attemptedNumber = _userInteractionService.GetAttemptedNumber();

                if (_configuration.RiddledNumber == attemptedNumber)
                {
                    _userInteractionService.Winner();
                    return;
                }
                else
                {
                    _userInteractionService.FalseGuess(attemptedNumber);

                    if (_configuration.WantsHints)
                    {
                        _userInteractionService.OutputMessage(_hintProvider.ProvideHint(_configuration.RiddledNumber, attemptedNumber));
                    }

                    _configuration.RemainingAttempts--;
                    _userInteractionService.RemainingAttempts(_configuration.RemainingAttempts);
                }

                if (_configuration.RemainingAttempts == 0)
                {
                    _userInteractionService.Looser(_configuration.RiddledNumber);
                }
            }
        }
    }
}
