using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web_Application.Models;

namespace Web_Application.Controllers;

public class AccountController : Controller
{
    
    private readonly SignInManager<IdentityUser> _signInManager;
    
    public AccountController(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // User can log in, perform any desired actions
                // For example, set authentication cookies and redirect
                // to a specific page or the returnUrl

                // For example, redirect to the Home page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // User cannot log in, display an error message and stay on the login page
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
        }
        return View(viewModel);
    }
    
    public IActionResult Register()
    {
        return View();
    }
}
