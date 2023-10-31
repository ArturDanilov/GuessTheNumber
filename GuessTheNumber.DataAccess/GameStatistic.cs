namespace GuessTheNumber.DataAccess
{
    public class GameStatistic
    {
        public int UserId { get; set; }
        public int TotalGamesCount { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public double AverageAttempts { get; set; }
        public int MinAttempts { get; set; }
        public int MaxAttempts { get; set; }

    }
}
