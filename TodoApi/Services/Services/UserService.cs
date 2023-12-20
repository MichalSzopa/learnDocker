using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using TodoApi.Database;
using TodoApi.Database.Models;

public class UserService : IUserService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IHeaderContextService _headerContextService;

    public UserService(IServiceScopeFactory scopeFactory, IHeaderContextService headerContextService)
        {
            _scopeFactory = scopeFactory;
            _headerContextService = headerContextService;
        }

    public async Task<IEnumerable<User>> GetUsers()
    {
        List<User> users = new List<User>();

            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                users = await db.Users.ToListAsync();
            }

            return users;
    }

    public async Task<List<Claim>> Login(string username, string password)
    {
        using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var user = await db.Users.Where(u => u.Name == username && u.Password == password).FirstOrDefaultAsync();
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
        using var context = new ApplicationDbContext();
        return await context.Users.Where(u => u.Name == "SYSTEM").FirstOrDefaultAsync(); // todo auth
    }
}