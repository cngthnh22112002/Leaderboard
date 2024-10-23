using Leaderboard.Dtos;

namespace Leaderboard.Services.Interfaces
{
    public interface ILeaderboardService
    {
        Task<PaginatedLeaderboardDTO> GetLeaderboardAsync(int gameId, int pageNumber, int pageSize, DateTime startTime, DateTime endTime);
        Task<UserRankDTO> GetUserRankAsync(int gameId, int userId);
    }
}
