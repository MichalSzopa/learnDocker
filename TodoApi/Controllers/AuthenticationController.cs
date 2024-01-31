using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
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
                return Ok(new { loggedIn = false });
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

            return Ok(new { loggedIn = true });
        }
        catch (Exception)
        {
            return Ok(new { loggedIn = false });
        }
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpPost("register")]
    public async Task<IActionResult> Register()
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpGet("login-test")]
    public ActionResult<object> LoginTest()
    {
        return Ok(new { loggedIn = true });
    }
}