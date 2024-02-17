using System.Security.Claims;


namespace JobFairAPI.Extensions
{
    public static class ClaimsPrinciplesExtensions
    {
        public static string GetUserEmail(this ClaimsPrincipal user){
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}