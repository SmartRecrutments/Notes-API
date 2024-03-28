using Logic.Models;

namespace Notes_API.Session
{
    public sealed class UserSession : IUserSession
    {
        private static User? loggedUser;

        public User? GetLoggedUser() => loggedUser;

        public void LogInUser(User user)
        {
            loggedUser = user;
        }
    }
}