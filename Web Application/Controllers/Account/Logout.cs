using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web_Application.Controllers.Account;

public partial class AccountController
{
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        _logger.LogInformation("Logout POST action called.");
        
        await _signInManager.SignOutAsync();
        
        _logger.LogInformation("User logged out successfully.");
        return RedirectToAction("Index", "Home");
    }
}