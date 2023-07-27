namespace GuessTheNumber
{
    internal class Logger
    {
        public void Try()
        {
            Console.WriteLine("Enter the number...");
        }

        public void Winner()
        {
            Console.WriteLine("You winn!!!");
        }

        public void Looser()
        {
            Console.WriteLine("You loose!!!");
        }

        public void NumberGuessed()
        {
            Console.WriteLine("Number guessed...");
        }

        public void InvalidInput()
        {
            Console.WriteLine("Invalid input, please enter a number between 1 and 10.");
        }
    }
}
