namespace GuessTheNumber.BusinessLogic
{
    internal interface IUserInteractionService
    {
        int GetAttemptedNumber();
        bool GetYesOrNoAnswer(string prompt);
        void FalseGuess(int attepts);
        void InvalidInput();
        void Looser(int attempts);
        void Try();
        void Winner();
        void RemainingAttempts(int count);
        void OutputMessage(string message);
    }
}