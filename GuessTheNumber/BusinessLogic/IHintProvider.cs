namespace GuessTheNumber.BusinessLogic
{
    public interface IHintProvider
    {
        string ProvideHint(int riddledNumber, int attemptedNumber);
    }
}
