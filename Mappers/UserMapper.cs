using AutoMapper;
using Leaderboard.Dtos;
using Leaderboard.Models;

namespace Leaderboard.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
        }
    }
}
