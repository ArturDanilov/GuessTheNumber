using System;
using GuessTheNumber.BusinessLogic;

namespace GuessTheNumber.Console
{
    internal class ConsoleUserInteractionService : IUserInteractionService
    {
        private const int MinValue = 1;
        private const int MaxValue = 10;

        public int GetAttemptedNumber()
        {
            while (true)
            {
                if (Int32.TryParse(System.Console.ReadLine(), out var attemptedNumber))
                {
                    if (attemptedNumber >= MinValue && attemptedNumber <= MaxValue)
                    {
                        return attemptedNumber;
                    }
                }

                InvalidInput();
                Try();
            }
        }

        public bool GetYesOrNoAnswer(string prompt)
        {
            while (true)
            {
                OutputMessage(prompt);
                string response = System.Console.ReadLine().ToLower();

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
                    OutputMessage("Please answer 'yes' or 'no'.");
                }
            }
        }
        public string AskQuestion(string question)
        {
            System.Console.Write(question);
            return System.Console.ReadLine();
        }

        public void Try() => System.Console.Write("\nEnter the number: ");

        public void Winner() => System.Console.Write("\nYou win!");

        public void Looser(int attempts) => System.Console.Write("\nYou loose! The hidden number was: " + attempts);

        public void InvalidInput() => System.Console.Write("\nInvalid input, please enter a number between 1 and 10.\n");

        public void FalseGuess(int attepts) => System.Console.Write(attepts + " is a false guess. ");

        public void RemainingAttempts(int count) => System.Console.Write("Remaining attempts " + count + ".\n");

        public void OutputMessage(string message) => System.Console.Write(message);
    }
}
