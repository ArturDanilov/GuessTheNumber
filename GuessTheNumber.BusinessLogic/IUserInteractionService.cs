namespace GuessTheNumber.BusinessLogic
{
    public interface IUserInteractionService
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
        string GetNickname();
        string GetName();
    }
}