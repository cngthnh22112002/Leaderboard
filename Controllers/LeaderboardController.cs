namespace Leaderboard.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Leaderboard.Services.Interfaces;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        private readonly ILeaderboardService _leaderboardService;

        public LeaderboardController(ILeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeaderboard(int gameId, int pageNumber = 1, int pageSize = 10, DateTime? startTime = null, DateTime? endTime = null)
        {
            if (!startTime.HasValue) startTime = DateTime.MinValue;
            if (!endTime.HasValue) endTime = DateTime.MaxValue;

            var leaderboard = await _leaderboardService.GetLeaderboardAsync(gameId, pageNumber, pageSize, startTime.Value, endTime.Value);
            return Ok(leaderboard);
        }


        [HttpGet]
        public async Task<IActionResult> GetUserRank(int gameId, int userId)
        {
            var userRank = await _leaderboardService.GetUserRankAsync(gameId, userId);
            if (userRank == null) return NotFound();
            return Ok(userRank);
        }
    }
}
