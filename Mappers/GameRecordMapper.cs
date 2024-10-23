using AutoMapper;
using Leaderboard.Dtos;
using Leaderboard.Models;

namespace Leaderboard.Mappers
{
    public class GameRecordMapper : Profile
    {
        public GameRecordMapper()
        {
            CreateMap<GameRecord, CreateGameRecordDto>().ReverseMap();
        }
    }
}
