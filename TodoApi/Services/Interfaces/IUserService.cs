using TodoApi.Database.Models;
using System.Security.Claims;

public interface IUserService
{
    Task<User> ValidateUserAsync(string username, string password);
    // Task<object> Register(RegisterDto dto);
    Task<List<Claim>> Login(string username, string password);
    Task<object> Logout();
    Task<IEnumerable<User>> GetUsers();
}