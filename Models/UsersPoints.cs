namespace ApiDelfin.Models
{
    public class UsersPoints
    {
        public int Id { get; set; }
        public int IdUsers { get; set; }
        public DateTime Date { get; set; }
        public int Points { get; set; }
        public int IdPoints { get; set; }
        public decimal PurchaseAmount { get; set; }
        public string Note { get; set; } = "";

        public User User { get; set; }
        public Point Point { get; set; }
    }
}
