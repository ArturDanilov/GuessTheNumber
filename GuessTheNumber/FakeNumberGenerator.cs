namespace GuessTheNumber
{
    internal class FakeNumberGenerator : INumberGenerator
    {
        private readonly int number;

        public FakeNumberGenerator(int number)
        {
            this.number = number;
        }

        public int GenerateNumber() => number;
    }
}
