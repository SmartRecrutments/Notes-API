namespace Logic;

using Logic.Interfaces;
using Logic.Models;

public class UserService : IUserService
{
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    private readonly List<User> _users = new()
    {
        new User { Id = 1, Username = "test1", Password = "test1" },
        new User { Id = 2, Username = "test2", Password = "test2" }
    };

    public async Task<User> Authenticate(string username, string password)
    {
        var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

        return user;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await Task.Run(() => _users);
    }
}