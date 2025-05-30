using Blazor.Models.Auth;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Providers
{
  public class AuthStateProvider : AuthenticationStateProvider
  {
    private readonly AuthTokenProvider _tokenProvider;

    public AuthStateProvider(AuthTokenProvider tokenProvider)
    {
      _tokenProvider = tokenProvider;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      ClaimsIdentity identity = _tokenProvider.IsAuthenticated
          ? new ClaimsIdentity(
          [
                  new Claim(ClaimTypes.Name, "User") // Optional: parse JWT claims
          ], "apiauth")
          : new ClaimsIdentity();

      return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
    }

    public void NotifyAuthenticationStateChanged()
    {
      NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
  }
}