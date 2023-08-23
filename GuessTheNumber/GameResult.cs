namespace GuessTheNumber
{
    internal class GameResult
    {
        public int Id { get; set; }

        public bool GameWon { get; set; }

        public int TotalAttempts { get; set; }

        public int AttemptsTaken { get; set; }

        public int RiddledNumber { get; set; }
    }
}
