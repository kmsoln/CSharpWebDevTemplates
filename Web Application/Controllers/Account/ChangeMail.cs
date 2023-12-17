using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Application.Models.Account;

namespace Web_Application.Controllers.Account;

public partial class AccountController
{
    
    [Authorize]
    [HttpGet]
    public IActionResult ChangeMail()
    {
        _logger.LogInformation("ChangeMail GET action called.");
        return View();
    }
    
    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangeMail(ChangeMailViewModel model)
    {
        _logger.LogInformation("ChangeMail POST action called.");
        
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            
            if (user != null)
            {
                try
                {
                    user.Email = model.NewEmail;
                    var result = await _userManager.UpdateAsync(user);
                    
                    if (result.Succeeded)
                    {
                        _logger.LogInformation($"Email change successful for user {user.UserName}.");
                        return RedirectToAction("Profile");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                            _logger.LogError($"Error updating user email: {error.Description}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"An error occurred while updating user email: {ex.Message}");
                    // Handle other exception details if needed
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "User not found.");
                _logger.LogError("User not found during email change.");
            }
        }
        
        return View(model);
    }
}