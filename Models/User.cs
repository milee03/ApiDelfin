namespace ApiDelfin.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Dni { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public int Points { get; set; } = 0;
        public bool IsAdmin { get; set; } = false;

        public ICollection<UsersPoints> UsersPoints { get; set; } = new List<UsersPoints>();
        public ICollection<UsersRewards> UsersRewards { get; set; } = new List<UsersRewards>();
    }
}
