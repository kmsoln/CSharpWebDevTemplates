using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web_Application.Models;

namespace Web_Application.Controllers;

public class AccountController : Controller
{
    
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
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
    
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "The password and confirmation password do not match.");
                return View(model);
            }

            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Registration successful, redirect to the Home page
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
            
        // Redirect to the Home page or another page after logout
        return RedirectToAction("Index", "Home");
    }
    
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
    
    [HttpGet]
    [Authorize]
    public IActionResult ChangePassword()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login");
        }

        var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

        if (changePasswordResult.Succeeded)
        {
            // Password changed successfully, you can redirect to a success page or perform other actions
            return RedirectToAction("Index", "Home");
        }
        else
        {
            // Password change failed, add errors to the ModelState
            foreach (var error in changePasswordResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
    }
}
