namespace GuessTheNumber
{
    internal interface ILogger
    {
        void FalseGuess(int attepts);
        void InvalidInput();
        void Looser(int attempts);
        void Try();
        void Winner();
        void RemainingAttempts(int count);
    }
}