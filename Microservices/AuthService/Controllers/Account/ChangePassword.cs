using AuthService.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.Account;

public partial class AccountController
{
    // PUT: api/Account/ChangePassword
       [HttpPut("ChangePassword")]
    [Authorize]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
    {
        // Log action entry
        Log(LogLevel.Information, "ChangePassword PUT action called.");

        // Retrieve the username of the currently authenticated user
        var username = User.Identity.Name;

        // Retrieve the user from the user manager using the username
        var user = await userManager.FindByNameAsync(username);

        // Check if the user exists
        if (user == null)
        {
            // Log and return a 404 Not Found if the user is not found
            Log(LogLevel.Warning, "ChangePassword: User not found.");
            return NotFound(new { Message = "User not found." });
        }

        try
        {
            // Attempt to change the user's password
            var changePasswordResult = await userManager.ChangePasswordAsync(
                user,
                model.OldPassword!,
                model.NewPassword!
            );

            // Check if the password change was successful
            if (changePasswordResult.Succeeded)
            {
                // Password changed successfully, you can return a 200 OK response or perform other actions
                Log(LogLevel.Information, $"Password changed successfully for user {user.UserName}.");
                return Ok(new { Message = "Password changed successfully." });
            }

            // If there are errors during password change, return a 400 Bad Request with error details
            foreach (var error in changePasswordResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
                Log(LogLevel.Error, $"Error changing password for user {user.UserName}: {error.Description}");
            }

            return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
        catch (Exception ex)
        {
            // Log any exceptions that occurred during password change and return a 500 Internal Server Error
            Log(LogLevel.Error, $"An error occurred while changing password: {ex.Message}");
            return StatusCode(500, new { Message = "Internal Server Error" });
            // Handle other exception details if needed
        }
    }
}