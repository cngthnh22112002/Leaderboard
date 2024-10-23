using Leaderboard.Dtos;

namespace Leaderboard.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUserWithPlayForAllGamesAsync(CreateUserDto createUserDto);
    }
}
