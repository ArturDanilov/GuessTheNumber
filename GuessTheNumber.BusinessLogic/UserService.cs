using GuessTheNumber.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GuessTheNumber.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _dbContext;

        public UserService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserEntity> CheckUserAsync(string nickname)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Nickname == nickname);
        }

        public async Task<UserEntity> CreateUserAsync(string nickname, string name)
        {
            var user = new UserEntity { Nickname = nickname, Name = name };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
