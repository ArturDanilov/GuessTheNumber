namespace GuessTheNumber
{
    internal class GameConfigurationManager
    {
        private INumberGenerator _numberGenerator;
        private IUserInteractionService _userInteractionService;


        public GameConfigurationManager(INumberGenerator numberGenerator, IUserInteractionService userInput)
        {
            _numberGenerator = numberGenerator;
            _userInteractionService = userInput;
        }

        public PrepareConfiguration ConfigureGame()
        {
            int _riddledNumber = _numberGenerator.GenerateNumber(); 
            int _defaultAttempts = 3;
            int _remainingAttempts;
            bool _userWantsHints;

            if (_userInteractionService.GetYesOrNoAnswer("Do you want to customize this game? (yes/no) "))
            {                
                _userInteractionService.OutputMessage("Please, enter the number of attempts: ");
                _remainingAttempts = _userInteractionService.GetAttemptedNumber();
                _userWantsHints = _userInteractionService.GetYesOrNoAnswer("Do you want to enable hints? (yes/no) ");
            }
            else
            {
                _remainingAttempts = _defaultAttempts;
                _userWantsHints = false;

                _userInteractionService.OutputMessage($"The game is installed with default settings. You have {_defaultAttempts} tries");
            }

            return new PrepareConfiguration
            {
                RiddledNumber = _riddledNumber,
                RemainingAttempts = _remainingAttempts,
                WantsHints = _userWantsHints
            };
        }
    }
}
