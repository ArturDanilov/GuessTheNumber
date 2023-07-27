namespace GuessTheNumber
{
    internal class NumberGenerator
    {
        public int GenerateNumber()
        {
            Random random = new Random();
            return random.Next(1, 10);
        }
    }
}
