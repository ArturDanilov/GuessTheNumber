namespace GuessTheNumber
{
    internal interface ILogger
    {
        void FalseGuess();
        void InvalidInput();
        void Looser();
        void NumberGuessed();
        void Try();
        void Winner();
    }
}