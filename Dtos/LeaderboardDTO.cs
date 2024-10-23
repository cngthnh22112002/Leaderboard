namespace Leaderboard.Dtos
{
    public class LeaderboardDTO
    {
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public int TotalPoint { get; set; }
        public int Rank { get; set; }
    }

    public class PaginatedLeaderboardDTO
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public List<LeaderboardDTO> Players { get; set; }
    }
}
