using System.ComponentModel.DataAnnotations;

namespace AuthService.Models.Account;

public class ChangeMailModel
{
    [Required(ErrorMessage = "New Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string? NewEmail { get; set; }

    [Compare("NewEmail", ErrorMessage = "Emails do not match")]
    public string? ConfirmNewEmail { get; set; }
}
