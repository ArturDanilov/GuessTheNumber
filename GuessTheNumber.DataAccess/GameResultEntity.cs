namespace GuessTheNumber.DataAccess
{
    public class GameResultEntity
    {
        public int Id { get; set; }

        public DateTimeOffset GameDate { get; set; }

        public bool GameWon { get; set; }

        public int TotalAttempts { get; set; }

        public int AttemptsTaken { get; set; }

        public int RiddledNumber { get; set; }

        public bool HintsEnabled { get; set; }
    }
}
