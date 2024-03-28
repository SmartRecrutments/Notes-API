using Logic.Models;

namespace Notes_API.Session
{
    public sealed class UserSession : IUserSession
    {
        private static User? _loggedUser;

        public User? GetLoggedUser() => _loggedUser;

        public void LogInUser(User user)
        {
            _loggedUser = user;
        }
    }
}