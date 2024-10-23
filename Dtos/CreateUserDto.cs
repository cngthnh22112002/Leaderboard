namespace Leaderboard.Dtos
{
    public class CreateUserDto
    {
        public string Role { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int GameId { get; set; }
        public int TotalPoint { get; set; }
    }
}
