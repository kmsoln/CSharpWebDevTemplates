using AuthService.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.Account;

public partial class AccountController
{
    // POST: api/Account/Login
    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginModel viewModel)
    {
        // Log action entry
        Log(LogLevel.Information, "Login POST action called.");

        // Check if the model state is valid
        if (ModelState.IsValid)
        {
            // Attempt to sign in the user using the provided credentials
            var result = await signInManager.PasswordSignInAsync(
                viewModel.Email!,
                viewModel.Password!,
                viewModel.RememberMe,
                false
            );

            // Check if the login attempt was successful
            if (result.Succeeded)
            {
                // User can log in, perform any desired actions
                // For example, set authentication cookies and return a success response

                Log(LogLevel.Information, $"User {viewModel.Email} logged in successfully.");
                return Ok(new { Message = "Login successful." });
            }

            // User cannot log in, return a 401 Unauthorized response with an error message
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            Log(LogLevel.Warning, $"Invalid login attempt for user {viewModel.Email}.");
            return Unauthorized(new { Errors = new[] { "Invalid login attempt." } });
        }

        // If the model state is not valid, return a 400 Bad Request with error details
        Log(LogLevel.Warning, "Login POST action: ModelState is not valid.");
        return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
    }
}