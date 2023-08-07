namespace GuessTheNumber
{
    internal class HintProvider : IHintProvider
    {
        public string ProvideHint(int riddledNumber, int attemptedNumber)
        {
            return riddledNumber > attemptedNumber ? "The number is great." : "The number is small.";
        }
    }
}
