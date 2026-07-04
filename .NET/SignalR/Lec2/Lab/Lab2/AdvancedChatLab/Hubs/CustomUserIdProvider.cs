using AdvancedChatLab.Data;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace AdvancedChatLab.Hubs
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            if (connection.User?.Identity?.IsAuthenticated == true)
            {
                // Directly return the User ID from the Token or Cookie Claims
                return connection.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return null;   // Return null if identity cannot be verified (will reject the connection)
        }
    }
}