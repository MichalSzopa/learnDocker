public interface IHeaderContextService
{
    public HttpContext? GetHttpContext();
    public Guid GetUserId();
}
