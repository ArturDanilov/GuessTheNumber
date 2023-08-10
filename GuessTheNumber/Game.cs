namespace GuessTheNumber
{
    internal class Game
    {
        private INumberGenerator _numberGenerator;
        private IUserInteractionService _userInteractionService;
        private IUserInput _userInput;
        private IHintProvider _hintProvider;
        private int _attempts = 3;
        private int riddledNumber, remainingAttempts;
        private bool userWantsHints;
        public Game(INumberGenerator numberGenerator, IUserInteractionService logger, IUserInput userInput, IHintProvider hintProvider)
        {
            _numberGenerator = numberGenerator;
            _userInteractionService = logger;
            _userInput = userInput;
            _hintProvider = hintProvider;
        }

        public void Start()
        {
            if (_userInput.GetYesOrNoAnswer("Do you want to customize this game? (yes/no) "))
            {
                ConfigureGameSettings();
            }
            else
            {
                riddledNumber = _numberGenerator.GenerateNumber();
                remainingAttempts = _attempts;
                userWantsHints = false;
                _userInteractionService.OutputMessage($"The game is installed with default settings. You have {_attempts} tries");
            }

            PlayGame();            
        }

        private void ConfigureGameSettings()
        {
            riddledNumber = _numberGenerator.GenerateNumber();

            if (_userInput.GetYesOrNoAnswer("Do you want to set the number of attempts? (yes/no) "))
            {
                _userInteractionService.OutputMessage("Please, enter the number of attempts: ");
                remainingAttempts = _userInput.GetAttemptedNumber();
            }
            else
            {
                remainingAttempts = _attempts;
            }

            userWantsHints = _userInput.GetYesOrNoAnswer("Do you want to enable hints? (yes/no) ");
        }

        private void PlayGame()
        {
            for (int i = 0; i < remainingAttempts; i++)
            {
                _userInteractionService.Try();
                var attemptedNumber = _userInput.GetAttemptedNumber();

                if (riddledNumber == attemptedNumber)
                {
                    _userInteractionService.Winner();
                    return;
                }
                else
                {
                    _userInteractionService.FalseGuess(attemptedNumber);

                    if (userWantsHints == true)
                    {
                        _userInteractionService.OutputMessage(_hintProvider.ProvideHint(riddledNumber, attemptedNumber));
                    }

                    _userInteractionService.RemainingAttempts(--remainingAttempts);
                }

                if (i == _attempts - 1)
                {
                    _userInteractionService.Looser(riddledNumber);
                }
            }
        }
    }
}
