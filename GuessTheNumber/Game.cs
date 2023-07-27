namespace GuessTheNumber
{
    internal class Game
    {
        private NumberGenerator numberGenerator;
        private Logger _logger;
        private int attempts = 3;

        public Game(NumberGenerator numberGenerator, Logger logger)
        {
            this.numberGenerator = numberGenerator;
            this._logger = logger;
        }

        public void TryGame()
        {
            int x = numberGenerator.GenerateNumber();
            _logger.NumberGuessed();

            if (x > attempts)
            {
                _logger.Try();
                var number = Int32.Parse(Console.ReadLine());

                //try 1
                if (x == number && attempts != 0)
                {
                    _logger.Winner();
                    attempts = 0;
                    return;
                }
                else
                {
                    number = OneMoreTry();
                }

                //try 2
                if (x == number && attempts != 0)
                {
                    _logger.Winner();
                }
                else
                {
                    number = OneMoreTry();
                }

                //try 3
                if (x == number && attempts > 0)
                {
                    _logger.Winner();
                }
                else
                {
                    attempts--;
                    _logger.Looser();
                }
            }
        }

        private int OneMoreTry()
        {
            int number;
            attempts--;
            _logger.Try();
            number = Int32.Parse(Console.ReadLine());
            return number;
        }
    }
}
