using AuthService.Auth;
using AuthService.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.Account;

public partial class AccountController 
{
    // POST: api/Account/Register
    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        // Log action entry
        Log(LogLevel.Information, "Register POST action called.");

        // Check if the model state is valid
        if (ModelState.IsValid)
        {
            // Check if the entered password matches the confirmation password
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "The password and confirmation password do not match.");
                Log(LogLevel.Warning, "Password and confirmation password do not match.");
                return BadRequest(new { Errors = new[] { "The password and confirmation password do not match." } });
            }

            // Create a new user with the provided email and username
            var user = new AppUser { UserName = model.Email, Email = model.Email };

            // Attempt to create the user using the user manager
            var result = await userManager.CreateAsync(user, model.Password!);

            // Check if user creation was successful
            if (result.Succeeded)
            {
                // Registration successful, return a 200 OK response or another appropriate status
                Log(LogLevel.Information, $"User {user.UserName} registered successfully.");
                return Ok(new { Message = "Registration successful." });
            }

            // If there are errors during user creation, return a 400 Bad Request with error details
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
                Log(LogLevel.Error, $"Error during user registration: {error.Description}");
            }

            return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }

        // If the model state is not valid, return a 400 Bad Request with error details
        Log(LogLevel.Warning, "Register POST action: ModelState is not valid.");
        return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
    }
}