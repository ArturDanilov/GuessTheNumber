namespace GuessTheNumber
{
    internal interface IUserInteractionService
    {
        void FalseGuess(int attepts);
        void InvalidInput();
        void Looser(int attempts);
        void Try();
        void Winner();
        void RemainingAttempts(int count);
        string AskQuestion(string question);
        void OutputMessage(string message);
    }
}