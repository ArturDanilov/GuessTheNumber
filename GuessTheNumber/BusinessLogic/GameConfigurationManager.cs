namespace GuessTheNumber.BusinessLogic
{
    internal class GameConfigurationManager //TODO Manager??
    {
        private IUserInteractionService _userInteractionService;

        public GameConfigurationManager(IUserInteractionService userInput)
        {
            _userInteractionService = userInput;
        }

        public GameConfiguration ConfigureGame()
        {
            int _defaultAttempts = 3;
            int _remainingAttempts;
            bool _userWantsHints;
            bool _userWantsStatistic = true;

            if (_userInteractionService.GetYesOrNoAnswer("Do you want to configure this game? (yes/no) "))
            {
                _userInteractionService.OutputMessage("Please, enter the number of attempts: ");
                _remainingAttempts = _userInteractionService.GetAttemptedNumber();
                _userWantsHints = _userInteractionService.GetYesOrNoAnswer("Do you want to enable hints? (yes/no) ");
                _userWantsStatistic = _userInteractionService.GetYesOrNoAnswer("Do you want to leave statistics enabled? (yes/no) ");
            }
            else
            {
                _remainingAttempts = _defaultAttempts;
                _userWantsHints = false;

                _userInteractionService.OutputMessage($"The game is installed with default settings. You have {_defaultAttempts} tries");
            }

            return new GameConfiguration
            {
                AttemptsCount = _remainingAttempts,
                HintsEnabled = _userWantsHints,
                TrackStatistics = _userWantsStatistic
            };
        }
    }
}
