using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Notes_API.Controllers;

public class UserController(IUserService userService) : ControllerBase
{
    [Route("user")]
    [HttpPost]
    public Task<IActionResult> AddUser(string username, string password)
    {
        userService.Register(username, password);

        return Task.FromResult<IActionResult>(Ok());
    }
}