using Microsoft.EntityFrameworkCore;

namespace GuessTheNumber.DataAccess
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly ApplicationContext _context;

        public StatisticsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<UserStatistics> GetPlayerStatisticsByNicknameAsync(string nickname)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);
            
            if (user == null)
            {
                return null;
            }

            var gameStatistic = await _context.GameResults
                .Where(gr => gr.UserId == user.Id)
                .GroupBy(gr => gr.UserId)
                .Select(g => new GameStatistic
                {
                    UserId = g.Key,
                    TotalGamesCount = g.Count(),
                    Wins = g.Count(gr => gr.GameWon),
                    Losses = g.Count(gr => !gr.GameWon),
                    AverageAttempts = g.Average(gr => gr.AttemptsTaken), // SQL & filter WIN count!!!
                    MinAttempts = g.Min(gr => gr.AttemptsTaken),
                    MaxAttempts = g.Max(gr => gr.AttemptsTaken) //new model
                })
                .FirstOrDefaultAsync();

            return new UserStatistics
            {
                Nickname = user.Nickname,
                Name = user.Name,
                TotalGamesCount = gameStatistic.TotalGamesCount,
                Wins = gameStatistic.Wins,
                Losses = gameStatistic.Losses
            };
        }

        public async Task<List<UserStatistics>> GetTop5PlayersByGameCountAsync()
        {
            var gameStats = await GetGameStatisticsAsync();
            var userNamesAndNicknames = await GetUserNicknamesAndNamesAsync();

            return gameStats.Select(stat => new UserStatistics
            {
                Nickname = userNamesAndNicknames[stat.UserId].Nickname,
                Name = userNamesAndNicknames[stat.UserId].Name,
                TotalGamesCount = stat.TotalGamesCount,
                Wins = stat.Wins,
                Losses = stat.Losses
            }).ToList();
        }

        private async Task<List<GameStatistic>> GetGameStatisticsAsync()
        {
            return await _context.GameResults
                .GroupBy(gr => gr.UserId)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => new GameStatistic
                {
                    UserId = g.Key,
                    TotalGamesCount = g.Count(),
                    Wins = g.Count(gr => gr.GameWon),
                    Losses = g.Count(gr => !gr.GameWon)
                })
                .ToListAsync();
        }

        private async Task<Dictionary<int, (string Nickname, string Name)>> GetUserNicknamesAndNamesAsync()
        {
            return await _context.Users
                .ToDictionaryAsync(u => u.Id, u => (u.Nickname, u.Name));
        }

    }
}
