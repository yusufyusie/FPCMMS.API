using FPCMMS.Application.Contracts;
using FPCMMS.Application.Contracts.Service;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FPCMMS.Application.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}
