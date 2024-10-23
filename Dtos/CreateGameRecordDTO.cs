namespace Leaderboard.Dtos
{
    public class CreateGameRecordDto
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int Point { get; set; }
    }
}
