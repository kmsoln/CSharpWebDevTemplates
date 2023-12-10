using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Application.Models;

namespace Web_Application.Controllers.Account;

public partial class AccountController
{
    [Authorize]
    public IActionResult Profile()
    {
        var user = _userManager.GetUserAsync(User).Result;

        var profileViewModel = new ProfileViewModel
        {
            UserName = user.UserName,
            Email = user.Email,
            // Populate other profile properties as needed
        };

        return View(profileViewModel);
    }
}