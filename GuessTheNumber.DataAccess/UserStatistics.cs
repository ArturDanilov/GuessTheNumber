﻿namespace GuessTheNumber.DataAccess
{
    public class UserStatistics
    {
        public string Nickname { get; set; } = String.Empty;

        public string Name { get; set; } = String.Empty;
        
        public int TotalGamesCount { get; set; }
        
        public int Wins { get; set; }
        
        public int Losses { get; set; }

        public double AverageAttempts { get; set; }

        public int MinAttempts { get; set; }

        public int MaxAttempts { get; set; }
    }

}
