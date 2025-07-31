using ApiDelfin.Data;
using ApiDelfin.Models;
namespace ApiDelfin.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) { _context = context; }

        public User? GetByDni(string dni) => _context.Users.SingleOrDefault(u => u.Dni == dni);

        public void Add(User user) => _context.Users.Add(user);

        public bool Exists(string dni) => _context.Users.Any(u => u.Dni == dni);

        public void Save() => _context.SaveChanges();

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

    }
}
