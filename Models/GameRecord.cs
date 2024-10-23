namespace Leaderboard.Models
{
    public class GameRecord
    {
        public int RecordId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int Point { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User User { get; set; }
        public Game Game { get; set; }

    }
}
