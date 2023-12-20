using System.Security.Claims;

public class HeaderContextService : IHeaderContextService
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public HeaderContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public HttpContext? GetHttpContext()
        {
            return _httpContextAccessor.HttpContext;
        }

        private ClaimsPrincipal GetUser()
        {
            return GetHttpContext()!.User;
        }

        public Guid GetUserId()
        {
            var claim = GetUser().FindFirstValue(ClaimTypes.NameIdentifier);
            return new Guid(claim);
        }
    }