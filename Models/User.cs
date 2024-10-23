using System.ComponentModel.DataAnnotations.Schema;

namespace Leaderboard.Models
{
    [Table("User")]
    public class User
    {
        public int UserId { get; set; }
        public string Role { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<GameRecord> GameRecords { get; set; }
        public ICollection<UserPlay> UserPlays {get; set;}
    }
}
