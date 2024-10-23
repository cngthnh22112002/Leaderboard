using Leaderboard.Dtos;

namespace Leaderboard.Services.Interfaces
{
    public interface IGameRecordService
    {
        Task AddGameRecordAsync(CreateGameRecordDto createGameRecordDto);
    }

}
