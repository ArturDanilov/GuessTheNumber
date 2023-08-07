namespace GuessTheNumber
{
    public interface IHintProvider
    {
        string ProvideHint(int riddledNumber, int attemptedNumber);
    }
}
