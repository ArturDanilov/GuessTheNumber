namespace GuessTheNumber
{
    internal class GameConfigurationManager
    {
        private INumberGenerator _numberGenerator;
        private IUserInput _userInput;

        public int RiddledNumber { get; private set; }
        public int RemainingAttempts { get; private set; }
        public bool UserWantsHints { get; private set; }

        public GameConfigurationManager(INumberGenerator numberGenerator, IUserInput userInput)
        {
            _numberGenerator = numberGenerator;
            _userInput = userInput;
        }

        public void DefaultConfiguration()
        {
            RiddledNumber = _numberGenerator.GenerateNumber();
            RemainingAttempts = 3;
            UserWantsHints = false;
        }

        public void UserConfiguration()
        {
            RiddledNumber = _numberGenerator.GenerateNumber();
            RemainingAttempts = _userInput.GetNumberOfAttempts();
            UserWantsHints = _userInput.GetYesOrNoAnswer("Do you want to enable hints? (yes/no) ");
        }
    }
}
