﻿namespace GuessTheNumber
{
    internal class Game
    {
        private INumberGenerator _numberGenerator;
        private IUserInteractionService _userInteractionService;
        private IHintProvider _hintProvider;
        private int _attempts = 3;
        private int _riddledNumber;
        private int _remainingAttempts;
        private bool _userWantsHints;
        public Game(INumberGenerator numberGenerator, IUserInteractionService userInput, IHintProvider hintProvider)
        {
            _numberGenerator = numberGenerator;
            _userInteractionService = userInput;
            _hintProvider = hintProvider;
        }

        //configuration
        public void Start()
        {
            if (_userInteractionService.GetYesOrNoAnswer("Do you want to customize this game? (yes/no) "))
            {
                ConfigureGameSettings();
            }
            else
            {
                //number generation
                _riddledNumber = _numberGenerator.GenerateNumber();

                //automatic retry setting
                _remainingAttempts = _attempts;

                //disabling hints
                _userWantsHints = false;

                _userInteractionService.OutputMessage($"The game is installed with default settings. You have {_attempts} tries");
            }

            PlayGame();            
        }

        private void ConfigureGameSettings()
        {
            //number generation
            _riddledNumber = _numberGenerator.GenerateNumber();

            //manual attempt setting
            _userInteractionService.OutputMessage("Please, enter the number of attempts: ");
            _remainingAttempts = _userInteractionService.GetAttemptedNumber();

            //hint selection
            _userWantsHints = _userInteractionService.GetYesOrNoAnswer("Do you want to enable hints? (yes/no) ");
        }

        //logic
        private void PlayGame()
        {
            while (_remainingAttempts > 0)
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

                    if (_userWantsHints == true)
                    {
                        _userInteractionService.OutputMessage(_hintProvider.ProvideHint(_riddledNumber, attemptedNumber));
                    }

                    _remainingAttempts--;
                    _userInteractionService.RemainingAttempts(_remainingAttempts);
                }

                if (_remainingAttempts == 0)
                {
                    _userInteractionService.Looser(_riddledNumber);
                }
            }
        }
    }
}
