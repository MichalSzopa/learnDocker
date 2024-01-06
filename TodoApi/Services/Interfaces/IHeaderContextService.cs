public interface IHeaderContextService
{
    public HttpContext? GetHttpContext();
    public int GetUserId();
}
