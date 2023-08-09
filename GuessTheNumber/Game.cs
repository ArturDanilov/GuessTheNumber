namespace GuessTheNumber
{
    internal class Game
    {
        private INumberGenerator _numberGenerator;
        private IUserInteractionService _userInteractionService;
        private IUserInput _userInput;
        private IHintProvider _hintProvider;
        private int _attempts = 3;

        public Game(INumberGenerator numberGenerator, IUserInteractionService logger, IUserInput userInput, IHintProvider hintProvider)
        {
            _numberGenerator = numberGenerator;
            _userInteractionService = logger;
            _userInput = userInput;
            _hintProvider = hintProvider;
        }

        public void Start()
        {
            //setting
            int riddledNumber = _numberGenerator.GenerateNumber();

            string question = _userInteractionService.AskQuestion("Do you want to set the number of attempts? (yes/no)");
            
            if (question.ToLower() == "yes")
            {
                _userInteractionService.OutputMessage("Please, enter the number of attempts:");
                _attempts = _userInput.GetAttemptedNumber();
            }

            int remainingAttempts = _attempts;

            string answer = _userInteractionService.AskQuestion("Do you want to enable hints? (yes/no)");
            bool userWantsHints = answer.ToLower() == "yes";

            //control
            for (int i = 0; i < _attempts; i++)
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
                    _userInteractionService.RemainingAttempts(--remainingAttempts);

                    if (userWantsHints == true)
                    {
                        _userInteractionService.OutputMessage(_hintProvider.ProvideHint(riddledNumber, attemptedNumber));
                    }
                }

                if (i == _attempts - 1)
                {
                    _userInteractionService.Looser(riddledNumber);
                }
            }
        }
    }
}
