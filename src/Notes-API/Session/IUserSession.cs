using Logic.Models;

namespace Notes_API.Session
{
    public interface IUserSession
    {
        public User? GetLoggedUser();
        public void LogInUser(User user);
    }
}