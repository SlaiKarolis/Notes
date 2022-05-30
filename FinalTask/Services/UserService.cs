using System.Security.Claims;

namespace FinalTask.Services
{
    public class UserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        
        public UserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public string GetUserId()
        {
            return _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        }

    }
}
