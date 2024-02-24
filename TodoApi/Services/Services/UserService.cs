using System.Security.Claims;
using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace Services.Services;

public class UserService(IServiceScopeFactory scopeFactory, IHeaderContextService headerContextService)
    : IUserService
{
    public async Task<IEnumerable<User>> GetUsers()
    {
        using var scope = scopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        return await db.Users.ToListAsync();
    }

    public async Task<List<Claim>> Login(string username, string password)
    {
        using (var scope = scopeFactory.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var user = await db.Users.Where(u => u.Login == username && u.Password == password).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim ( ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim ( ClaimTypes.Name, username),
            };
            return claims;
        }
    }

    public Task<object> Logout()
    {
        return null;
    }

    public async Task<User> ValidateUserAsync(string username, string password)
    {
        await using var context = new ApplicationDbContext();
        return await context.Users.Where(u => u.Name == "SYSTEM").FirstOrDefaultAsync(); // TODO auth
    }
}