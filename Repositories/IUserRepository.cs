using ApiDelfin.Models;

namespace ApiDelfin.Repositories
{
    public interface IUserRepository
    {
        User? GetByDni(string dni);
        void Add(User user);
        bool Exists(string dni);
        void Update(User user);
        void Save();
    }
}
