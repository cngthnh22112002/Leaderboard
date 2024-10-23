using Microsoft.AspNetCore.Mvc;
using Leaderboard.Dtos;
using Leaderboard.Services.Interfaces;

namespace Leaderboard.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameRecordController : ControllerBase
    {
        private readonly IGameRecordService _gameRecordService;

        public GameRecordController(IGameRecordService gameRecordService)
        {
            _gameRecordService = gameRecordService;
        }

        [HttpPost]
        public async Task<IActionResult> AddGameRecord([FromBody] CreateGameRecordDto createGameRecordDto)
        {
            if (createGameRecordDto == null) return BadRequest();
            await _gameRecordService.AddGameRecordAsync(createGameRecordDto);
            return Ok();
        }
    }
}
