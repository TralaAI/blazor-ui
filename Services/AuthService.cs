using Blazor.Models.Auth;
using Blazor.Interfaces;
using Blazor.Providers;

namespace Blazor.Services
{
  public class AuthService(IHttpClientFactory httpClientFactory, AuthTokenProvider authTokenProvider, AuthStateProvider authStateProvider) : IAuthService
  {
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly AuthTokenProvider _tokenProvider = authTokenProvider;
    private readonly AuthStateProvider _authProvider = authStateProvider;


    public async Task<bool> LoginAsync(string email, string password)
    {
      var _client = _httpClientFactory.CreateClient("AuthClient");
      var requestData = new LoginRequest { Email = email, Password = password };
      var response = await _client.PostAsJsonAsync("/api/auth/login", requestData);

      if (!response.IsSuccessStatusCode)
        return false;

      var json = await response.Content.ReadFromJsonAsync<LoginResponse>();
      if (json is null)
        return false;

      _tokenProvider.AccessToken = json.Token;
      _tokenProvider.TokenExpiry = json.ExpiresAt;

      Console.WriteLine(json.Token);

      return true;
    }

    public void Logout()
    {
      _tokenProvider.AccessToken = null!;
      _tokenProvider.TokenExpiry = DateTime.Now;
      _authProvider.NotifyAuthenticationStateChanged();
    }
  }
}