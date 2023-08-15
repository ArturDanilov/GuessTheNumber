namespace GuessTheNumber
{
    internal class GameConfigurationManager
    {
        private INumberGenerator _numberGenerator;
        private IUserInteractionService _userInteractionService;
        private int _attempts = 3;
        private int _riddledNumber;
        private int _remainingAttempts;
        private bool _userWantsHints;

        public GameConfigurationManager(INumberGenerator numberGenerator, IUserInteractionService userInput)
        {
            _numberGenerator = numberGenerator;
            _userInteractionService = userInput;
        }

        public GameSettings ConfigureGame()
        {

            if (_userInteractionService.GetYesOrNoAnswer("Do you want to customize this game? (yes/no) "))
            {
                _riddledNumber = _numberGenerator.GenerateNumber();
                _userInteractionService.OutputMessage("Please, enter the number of attempts: ");
                _remainingAttempts = _userInteractionService.GetAttemptedNumber();
                _userWantsHints = _userInteractionService.GetYesOrNoAnswer("Do you want to enable hints? (yes/no) ");
            }
            else
            {
                _riddledNumber = _numberGenerator.GenerateNumber();
                _remainingAttempts = _attempts;
                _userWantsHints = false;

                _userInteractionService.OutputMessage($"The game is installed with default settings. You have {_attempts} tries");
            }

            return new GameSettings
            {
                RiddledNumber = _riddledNumber,
                RemainingAttempts = _remainingAttempts,
                WantsHints = _userWantsHints
            };
        }
    }
}
