namespace ApiDelfin.Models
{
    public class Point
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MoneyAmount { get; set; }
        public int PointsAwarded { get; set; }
        public string Description { get; set; } = "";

        public ICollection<UsersPoints> UsersPoints { get; set; } = new List<UsersPoints>();
    }
}
