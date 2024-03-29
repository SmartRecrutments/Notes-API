namespace Logic;

using Interfaces;
using Models;

public class UserService : IUserService
{
    private readonly List<User> _users =
    [
        new User { Id = 1, Username = "test1", Password = "test1" },
        new User { Id = 2, Username = "test2", Password = "test2" } // Passwords are stored in plain format without hash for demo purposes 
    ];

    public async Task<User?> Authenticate(string username, string password)
    {
        var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

        return user;
    }

    public void Register(string username, string password)
    {
        _users.Add(new User() { Id = _users.Last().Id + 1, Username = username, Password = password });
    }
}