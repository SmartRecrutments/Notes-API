namespace Notes_API.Models;

using System.ComponentModel.DataAnnotations;

public class AuthenticateModel
{
    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Password { get; set; }
}