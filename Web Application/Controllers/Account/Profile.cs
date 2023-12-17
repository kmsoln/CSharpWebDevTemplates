using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Application.Models;
using Web_Application.Models.Account;

namespace Web_Application.Controllers.Account;

public partial class AccountController
{
    
    [Authorize]
    public IActionResult Profile()
    {
        _logger.LogInformation("Profile GET action called.");
        
        var user = _userManager.GetUserAsync(User).Result;
        
        if (user != null)
        {
            var profileViewModel = new ProfileViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                // Populate other profile properties as needed
            };
            
            _logger.LogInformation($"User profile retrieved successfully for user {user.UserName}.");
            
            return View(profileViewModel);
        }
        else
        {
            _logger.LogError("User not found in Profile action.");
            return RedirectToAction("Error", "Home");
        }
    }
}