using GuessTheNumber.DataAccess;

namespace GuessTheNumber.BusinessLogic
{
    public interface IUserService
    {
        Task <UserEntity> CheckUserAsync(string nickname);

        Task <UserEntity> CreateUserAsync(string nickname, string name);
    }
}