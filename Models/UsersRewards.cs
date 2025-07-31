namespace ApiDelfin.Models
{
    public class UsersRewards
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RewardId { get; set; }
        public DateTime Date { get; set; }
        public int PointsSpent { get; set; }
        public string Notes { get; set; } = "";

        public User User { get; set; }
        public Reward Reward { get; set; }
    }
}
