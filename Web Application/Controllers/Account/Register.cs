using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Application.Auth;
using Web_Application.Models.Account;

namespace Web_Application.Controllers.Account;

public partial class AccountController 
{
    
    public IActionResult Register()
    {
        _logger.LogInformation("Register GET action called.");
        return View();
    }
    
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        _logger.LogInformation("Register POST action called.");
        
        if (ModelState.IsValid)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "The password and confirmation password do not match.");
                _logger.LogWarning("Password and confirmation password do not match.");
                return View(model);
            }
            
            var user = new AppUser { UserName = model.Email, Email = model.Email };
            
            var result = await _userManager.CreateAsync(user, model.Password!);
            
            if (result.Succeeded)
            {
                _logger.LogInformation($"User {user.UserName} registered successfully.");
                return RedirectToAction("Index", "Home");
            }
            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
                _logger.LogError($"Error during user registration: {error.Description}");
            }
        }
        
        _logger.LogWarning("Register POST action: ModelState is not valid.");
        return View(model);
    }
}