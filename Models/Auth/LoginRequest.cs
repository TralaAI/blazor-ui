using System.ComponentModel.DataAnnotations;

namespace Blazor.Models.Auth
{
  using System.ComponentModel.DataAnnotations;

  public class LoginRequest
  {
    [Required(ErrorMessage = "The Email field is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public required string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "The Password field is required.")]
    public required string Password { get; set; } = string.Empty;
  }
}