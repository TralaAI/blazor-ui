namespace Blazor.Models.Auth
{
    public class AuthTokenProvider
    {
        public required string AccessToken { get; set; }
        public DateTime TokenExpiry { get; set; }
        public bool IsAuthenticated => !string.IsNullOrEmpty(AccessToken) && TokenExpiry > DateTime.UtcNow;
    }

}