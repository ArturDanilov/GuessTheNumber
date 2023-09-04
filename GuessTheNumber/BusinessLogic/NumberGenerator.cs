namespace GuessTheNumber.BusinessLogic
{
    internal class NumberGenerator : INumberGenerator
    {
        public int GenerateNumber()
        {
            Random random = new Random();
            return random.Next(1, 10);
        }
    }
}
