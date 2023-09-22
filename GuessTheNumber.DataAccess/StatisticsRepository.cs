namespace GuessTheNumber.DataAccess
{
    public class StatisticsRepository
    {
        private readonly ApplicationContext _context;

        public StatisticsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IQueryable<UserStatistics> GetTop5PlayersByGameCount()
        {
            return _context.GameResults
                         .GroupBy(gr => new
                         {
                             gr.User.Nickname,
                             gr.User.Name
                         })
                         .OrderByDescending(g => g.Count())
                         .Take(5)
                         .Select(g => new UserStatistics
                         {
                             Nickname = g.Key.Nickname,
                             Name = g.Key.Name,
                             TotalGamesCount = g.Count(),
                             Wins = g.Count(gr => gr.GameWon),
                             Losses = g.Count(gr => !gr.GameWon)
                         });
        }
    }
}
