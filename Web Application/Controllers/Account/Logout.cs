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
        await _signInManager.SignOutAsync();
            
        // Redirect to the Home page or another page after logout
        return RedirectToAction("Index", "Home");
    }
}