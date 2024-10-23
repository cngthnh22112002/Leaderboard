using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Leaderboard.Data;
using Leaderboard.Dtos;
using Leaderboard.Models;
using Leaderboard.Repositories.Interfaces;
using Leaderboard.Services.Interfaces;

namespace Leaderboard.Services.Implementations
{
    public class LeaderBoardService : ILeaderboardService
    {
        private readonly IGenericRepository<UserPlay> _userPlayRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public LeaderBoardService(
            IGenericRepository<UserPlay> userPlayRepository,
            IGenericRepository<User> userRepository,
            IMapper mapper,
            AppDbContext context)
        {
            _userPlayRepository = userPlayRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Get the leaderboard for a specific game within a time range, paginated.
        /// </summary>
        /// <param name="gameId">The ID of the game.</param>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The size of each page for pagination.</param>
        /// <param name="startTime">The start time of the period to consider.</param>
        /// <param name="endTime">The end time of the period to consider.</param>
        /// <returns>A paginated leaderboard DTO containing the leaderboard data.</returns>
        public async Task<PaginatedLeaderboardDTO> GetLeaderboardAsync(int gameId, int pageNumber, int pageSize, DateTime startTime, DateTime endTime)
        {
            var userPlays = await _context.UserPlays
                .Where(up => up.GameId == gameId && up.CreatedAt >= startTime && up.CreatedAt <= endTime)
                .Include(up => up.User)
                .OrderByDescending(up => up.TotalPoint)
                .ThenBy(up => up.UpdatedAt) // Use UpdatedAt for secondary sorting
                .ToListAsync();

            var totalPlayers = userPlays.Count;
            var totalPages = (int)Math.Ceiling(totalPlayers / (double)pageSize);

            var paginatedUserPlays = userPlays
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select((up, index) => new LeaderboardDTO
                {
                    FullName = up.User.Fullname,
                    Avatar = up.User.Avatar,
                    TotalPoint = up.TotalPoint,
                    Rank = (pageNumber - 1) * pageSize + index + 1
                })
                .ToList();

            return new PaginatedLeaderboardDTO
            {
                CurrentPage = pageNumber,
                TotalPages = totalPages,
                PageSize = pageSize,
                Players = paginatedUserPlays
            };
        }

        /// <summary>
        /// Get the rank and total points of a specific user in a specific game.
        /// </summary>
        /// <param name="gameId">The ID of the game.</param>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A DTO containing the user's rank and total points.</returns>
        public async Task<UserRankDTO> GetUserRankAsync(int gameId, int userId)
        {
            var userPlay = await _context.UserPlays
                .Where(up => up.GameId == gameId && up.UserId == userId)
                .FirstOrDefaultAsync();

            if (userPlay == null) return null;

            var leaderboard = await _context.UserPlays
                .Where(up => up.GameId == gameId)
                .OrderByDescending(up => up.TotalPoint)
                .ThenBy(up => up.UpdatedAt)
                .ToListAsync();

            for (int i = 0; i < leaderboard.Count; i++)
            {
                if (leaderboard[i].UserId == userId)
                {
                    return new UserRankDTO
                    {
                        UserId = userId,
                        Rank = i + 1,
                        TotalPoint = userPlay.TotalPoint
                    };
                }
            }
            return null;
        }
    }
}