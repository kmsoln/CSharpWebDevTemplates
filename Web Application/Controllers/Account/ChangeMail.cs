using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Application.Models;

namespace Web_Application.Controllers.Account;

public partial class AccountController
{
    [Authorize]
    [HttpGet]
    public IActionResult ChangeMail()
    {
        // Implement logic to display the ChangeMail view
        return View();
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangeMail(ChangeMailViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                user.Email = model.NewEmail;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    // Email change successful, redirect to a success page or another action
                    return RedirectToAction("Profile");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            else
            {
                // Handle the case where the user cannot be found
                ModelState.AddModelError(string.Empty, "User not found.");
            }
        }

        return View(model);
    }
}