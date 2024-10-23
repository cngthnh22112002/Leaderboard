namespace Leaderboard.Models
{
    public class UserPlay
    {
        public int PlayId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int TotalPoint { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User User { get; set; }
        public Game Game { get; set;  }
    }
}
