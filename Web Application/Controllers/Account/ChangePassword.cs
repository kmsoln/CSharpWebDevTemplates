using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Application.Models.Account;

namespace Web_Application.Controllers.Account;

public partial class AccountController
{
    
    [HttpGet]
    [Authorize]
    public IActionResult ChangePassword()
    {
        _logger.LogInformation("ChangePassword GET action called.");
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        _logger.LogInformation("ChangePassword POST action called.");
        
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("ChangePassword: ModelState is not valid.");
            return View(model);
        }
        
        var user = await _userManager.GetUserAsync(User);
        
        if (user == null)
        {
            _logger.LogWarning("ChangePassword: User not found. Redirecting to Login.");
            return RedirectToAction("Login");
        }

        try
        {
            var changePasswordResult = await _userManager.ChangePasswordAsync(
                user, 
                model.OldPassword!, 
                newPassword:model.NewPassword!
            );
            
            if (changePasswordResult.Succeeded)
            {
                _logger.LogInformation($"Password changed successfully for user {user.UserName}.");
                return RedirectToAction("Profile", "Account");
            }
            else
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    _logger.LogError($"Error changing password for user {user.UserName}: {error.Description}");
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred while changing password: {ex.Message}");
            // Handle other exception details if needed
        }
        
        return View(model);
    }
}