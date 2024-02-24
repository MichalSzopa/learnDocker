using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Services.Interfaces;

namespace Services.Services;

public class HeaderContextService(IHttpContextAccessor httpContextAccessor) : IHeaderContextService
{
    public HttpContext? GetHttpContext()
    {
        return httpContextAccessor.HttpContext;
    }


    public int GetUserId()
    {
        return int.Parse(GetUser().FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
    
    private ClaimsPrincipal GetUser()
    {
        return GetHttpContext()!.User;
    }
}