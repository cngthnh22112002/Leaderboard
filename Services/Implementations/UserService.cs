using AutoMapper;
using Leaderboard.Data;
using Leaderboard.Dtos;
using Leaderboard.Models;
using Leaderboard.Repositories.Interfaces;
using Leaderboard.Services.Interfaces;

namespace Leaderboard.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<UserPlay> _userPlayRepository;
        private readonly IGenericRepository<Game> _gameRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public UserService(
            IGenericRepository<User> userRepository,
            IGenericRepository<UserPlay> userPlayRepository,
            IGenericRepository<Game> gameRepository,
            IMapper mapper,
            AppDbContext context)
        {
            _userRepository = userRepository;
            _userPlayRepository = userPlayRepository;
            _gameRepository = gameRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateUserWithPlayForAllGamesAsync(CreateUserDto createUserDto)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = _mapper.Map<User>(createUserDto);
                    await _userRepository.InsertAsync(user);

                    var allGames = await _gameRepository.GetAllAsync();

                    // Create UserPlay for each game
                    foreach (var game in allGames)
                    {
                        var userPlay = new UserPlay
                        {
                            UserId = user.UserId,
                            GameId = game.GameId,
                            TotalPoint = createUserDto.TotalPoint,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        };
                        await _userPlayRepository.InsertAsync(userPlay);
                    }

                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
