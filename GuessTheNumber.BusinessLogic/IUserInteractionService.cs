namespace GuessTheNumber.BusinessLogic
{
    public interface IUserInteractionService
    {
        int GetAttemptedNumber();
        string Read();
        string GetNickname();
        string GetName();
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