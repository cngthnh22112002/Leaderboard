using Microsoft.AspNetCore.Mvc;
using Leaderboard.Dtos;
using Leaderboard.Services.Interfaces;

namespace Leaderboard.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserWithPlay([FromBody] CreateUserDto createUserDto)
        {
            if (createUserDto == null) return BadRequest();
            await _userService.CreateUserWithPlayForAllGamesAsync(createUserDto);
            return Ok();
        }
    }
}
