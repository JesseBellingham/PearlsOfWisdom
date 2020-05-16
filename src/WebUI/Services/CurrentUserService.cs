using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using PearlsOfWisdom.Application.Common.Interfaces;

namespace WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}