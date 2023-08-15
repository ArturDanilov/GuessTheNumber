﻿namespace GuessTheNumber
{
    internal class ConsoleUserInput : IUserInput
    {
        private IUserOutput _userInteractionService;
        private const int MinValue = 1;
        private const int MaxValue = 10;

        public ConsoleUserInput(IUserOutput userOutput)
        {
            _userInteractionService = userOutput;
        }
        public int GetAttemptedNumber()
        {
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out var attemptedNumber))
                {
                    if (attemptedNumber >= MinValue && attemptedNumber <= MaxValue)
                    {
                        return attemptedNumber;
                    }
                }

                _userInteractionService.InvalidInput();
                _userInteractionService.Try();
            }
        }

        public int GetNumberOfAttempts()
        {
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out var numberOfAttempts))
                {
                    if (numberOfAttempts >= 1)
                    {
                        return numberOfAttempts;
                    }

                    _userInteractionService.InvalidInput();
                }
            }
        }

        public bool GetYesOrNoAnswer(string prompt)
        {
            while (true)
            {
                _userInteractionService.OutputMessage(prompt);
                string response = Console.ReadLine().ToLower();

                if (response == "yes")
                {
                    return true;
                }
                else if (response == "no")
                {
                    return false;
                }
                else
                {
                    _userInteractionService.OutputMessage("Please answer 'yes' or 'no'.");
                }
            }
        }

        public void Try() => Console.Write("\nEnter the number: ");

        public void Winner() => Console.WriteLine("\nYou win!");

        public void Looser(int attempts) => Console.Write("\nYou loose! The hidden number was: " + attempts);

        public void InvalidInput() => Console.Write("\nInvalid input, please enter a number between 1 and 10.\n");

        public void FalseGuess(int attepts) => Console.Write(attepts + " is a false guess. ");

        public void RemainingAttempts(int count) => Console.Write("Remaining attempts " + count + ".\n");

        public string AskQuestion(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }

        public void OutputMessage(string message) => Console.Write(message);
    }
}
