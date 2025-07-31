namespace ApiDelfin.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Cost { get; set; }

        public ICollection<UsersRewards> UsersRewards { get; set; } = new List<UsersRewards>();
    }
}
