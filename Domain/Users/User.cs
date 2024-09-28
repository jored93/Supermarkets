// Domain/Users/User.cs
using Domain.Primitives;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Users;

public sealed class User : AggregateRoot
{
    public User(UserId id, string name, string lastName, string email, string username, string password, bool isActive)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Email = email;
        Username = username;
        Password = EncryptPassword(password);
        IsActive = isActive;
    }

    private User() { }

    public UserId Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public bool IsActive { get; set; }

    private static string EncryptPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }
}
