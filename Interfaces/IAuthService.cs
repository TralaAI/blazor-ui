namespace Blazor.Interfaces
{
  public interface IAuthService
  {
    Task<bool> LoginAsync(string username, string password);
    void Logout();
  }
}