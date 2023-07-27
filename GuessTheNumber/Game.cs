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

            for (int i = 0; i < attempts; i++)
            {
                _logger.Try();
                if (Int32.TryParse(Console.ReadLine(), out var number))
                {
                    if (x == number)
                    {
                        _logger.Winner();
                        return;
                    }
                    else
                    {
                        _logger.FalseGuess();
                    }
                }
                else
                {
                    _logger.InvalidInput();
                    i--;
                }

                if (i == attempts - 1) _logger.Looser();
            }
        }
    }
}
