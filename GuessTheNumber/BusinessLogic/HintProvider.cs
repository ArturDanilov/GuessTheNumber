namespace GuessTheNumber.BusinessLogic
{
    internal class HintProvider : IHintProvider
    {
        public string ProvideHint(int riddledNumber, int attemptedNumber)
        {
            return riddledNumber > attemptedNumber ? "The number is greater. " : "The number is less. ";
        }
    }
}
