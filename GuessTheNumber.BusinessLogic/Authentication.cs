using GuessTheNumber.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GuessTheNumber.BusinessLogic
{
    //UserService
    public class Authentication : IAuthentication
    {
        private readonly ApplicationContext _dbContext;

        public Authentication(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CheckUser

        // GetUser
        
        //Login 
        public void Authorization()
        {
            Console.Write("Please enter your nickname: ");
            string? nickname = Console.ReadLine();

            var user = _dbContext.GetOrCreateUser(nickname);

            if (user == null)
            {
                Console.WriteLine("Please enter your name: ");
                string? name = Console.ReadLine();
                user = _dbContext.GetOrCreateUser(nickname, name);
            }
            else
            {
                Console.WriteLine($"Welcome back, {user.Nickname}!");
            }
        }
    }
}
