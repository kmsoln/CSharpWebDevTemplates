using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Application.Models.Account;

namespace Web_Application.Controllers.Account;

public partial class AccountController
{
    
    public IActionResult Login()
    {
        _logger.LogInformation("Login GET action called.");
        return View();
    }
    
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel viewModel)
    {
        _logger.LogInformation("Login POST action called.");
        
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(
                viewModel.Email!, 
                viewModel.Password!, 
                viewModel.RememberMe, 
                lockoutOnFailure: false
            );
            
            if (result.Succeeded)
            {
                _logger.LogInformation($"User {viewModel.Email} logged in successfully.");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                _logger.LogWarning($"Invalid login attempt for user {viewModel.Email}.");
            }
        }
        
        _logger.LogWarning("Login POST action: ModelState is not valid.");
        return View(viewModel);
    }
}