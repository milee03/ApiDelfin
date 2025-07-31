using BCrypt.Net;
using ApiDelfin.Models;
using ApiDelfin.Repositories;

namespace ApiDelfin.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo) { _repo = repo; }

        public bool Register(string name, string dni, string password, bool isAdmin)
        {
            if (_repo.Exists(dni)) return false;

            var user = new User
            {
                Name = name,
                Dni = dni,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Points = 0,
                IsAdmin = isAdmin
            };

            _repo.Add(user);
            _repo.Save();
            return true;
        }

        public User? ValidateUser(string dni, string password)
        {
            var user = _repo.GetByDni(dni);
            if (user == null) return null;

            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash) ? user : null;
        }
    }
}
