using Microsoft.AspNetCore.Http;

namespace Services.Interfaces;

public interface IHeaderContextService
{
    public HttpContext? GetHttpContext();
    public int GetUserId();
}