namespace GuessTheNumber.DataAccess
{
    internal class UserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
    }
}
