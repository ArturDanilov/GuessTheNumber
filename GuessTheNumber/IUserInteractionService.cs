namespace GuessTheNumber
{
    internal interface IUserInteractionService : IUserOutput
    {
        int GetAttemptedNumber();
        int GetNumberOfAttempts();
        bool GetYesOrNoAnswer(string prompt);
    }
}