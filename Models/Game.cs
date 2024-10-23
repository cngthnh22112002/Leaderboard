using System.ComponentModel.DataAnnotations.Schema;

namespace Leaderboard.Models
{
    [Table("Game")]
    public class Game
    {
        public int GameId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<GameRecord> GameRecords { get; set; }
        public ICollection<UserPlay> UserPlays { get; set; }
    }

}
