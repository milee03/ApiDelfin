using ApiDelfin.Models;
namespace ApiDelfin.Services
{
    public interface IUserService
    {
        bool Register(string name, string dni, string password, bool isAdmin);
        User? ValidateUser(string dni, string password);

        bool Update(string dni, string? name = null, string? password = null, bool? isAdmin = null);
    }
}
