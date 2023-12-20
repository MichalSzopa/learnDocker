using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public AuthController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        try
        {
            var claims = await _userService.Login(model.Username, model.Password);

            if (claims == null)
            {
                return Ok(new { loggedin = false });
            }

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(15),
                    IssuedUtc = DateTimeOffset.UtcNow,
                });

            // Konwertuje automatycznie na JSON
            return Ok(new { loggedIn = true });
        }
        catch (Exception)
        {
            // Zwracanie anonimowego typu
            // Konwertuje automatycznie na JSON
            return Ok(new { loggedin = false });
        }

        // var user = await _userService.ValidateUserAsync(model.Username, model.Password);

        // if (user == null)
        //     return Unauthorized("Invalid username or password");

        // // Generate token or perform other authentication logic
        // var token = GenerateToken(user.Name);

        // return Ok(new { Token = token });
    }

    [Authorize]
    [HttpGet("/api/login-test")]
    public ActionResult<object> LoginTest()
    {
        // Konwertuje automatycznie na JSON
        return Ok(new { loggedin = true });
    }

    // This is just an example, use proper token generation methods
    private string GenerateToken(string username)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKeyHerealetrochedluzszymozeXddddd")); // todo
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: new[] { new Claim(ClaimTypes.Name, username) },
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}