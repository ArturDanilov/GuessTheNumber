namespace GuessTheNumber
{
    internal interface IUserInput
    {
        int GetAttemptedNumber();
        int GetNumberOfAttempts();
        bool GetYesOrNoAnswer(string prompt);
    }
}