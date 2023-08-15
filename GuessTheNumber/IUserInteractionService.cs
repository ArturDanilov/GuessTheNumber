namespace GuessTheNumber
{
    internal interface IUserInput : IUserOutput
    {
        int GetAttemptedNumber();
        int GetNumberOfAttempts();
        bool GetYesOrNoAnswer(string prompt);
    }
}