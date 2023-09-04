namespace GuessTheNumber.BusinessLogic
{
    public class HintProvider : IHintProvider
    {
        public string ProvideHint(int riddledNumber, int attemptedNumber)
        {
            return riddledNumber > attemptedNumber ? "The number is greater. " : "The number is less. ";
        }
    }
}
