using Logic.Models;

namespace Logic.Interfaces
{
    public interface IUserService
    {
        Task<User?> Authenticate(string username, string password);
        void Register(string username, string password);
    }
}