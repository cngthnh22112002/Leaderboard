using AutoMapper;
using Leaderboard.Data;
using Leaderboard.Dtos;
using Leaderboard.Models;
using Leaderboard.Repositories.Interfaces;
using Leaderboard.Services.Interfaces;

namespace Leaderboard.Services.Implementations
{
    public class GameRecordService : IGameRecordService
    {
        private readonly IGenericRepository<GameRecord> _gameRecordRepository;
        private readonly IGenericRepository<UserPlay> _userPlayRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public GameRecordService(
            IGenericRepository<GameRecord> gameRecordRepository,
            IGenericRepository<UserPlay> userPlayRepository,
            IMapper mapper,
            AppDbContext context)
        {
            _gameRecordRepository = gameRecordRepository;
            _userPlayRepository = userPlayRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task AddGameRecordAsync(CreateGameRecordDto createGameRecordDto)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Create GameRecord
                    var gameRecord = _mapper.Map<GameRecord>(createGameRecordDto);
                    gameRecord.CreatedAt = DateTime.Now;
                    gameRecord.UpdatedAt = DateTime.Now;
                    await _gameRecordRepository.InsertAsync(gameRecord);

                    // Update UserPlay
                    var userPlay = await _userPlayRepository.FirstOrDefaultAsync(up => up.UserId == createGameRecordDto.UserId && up.GameId == createGameRecordDto.GameId);

                    if (userPlay != null)
                    {
                        userPlay.TotalPoint += createGameRecordDto.Point;
                        userPlay.UpdatedAt = DateTime.Now;
                        await _userPlayRepository.UpdateAsync(userPlay);
                    }
                    else
                    {
                        userPlay = new UserPlay
                        {
                            UserId = createGameRecordDto.UserId,
                            GameId = createGameRecordDto.GameId,
                            TotalPoint = createGameRecordDto.Point,
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
