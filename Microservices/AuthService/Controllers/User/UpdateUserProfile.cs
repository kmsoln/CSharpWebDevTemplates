using AuthService.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.User;

public partial class UserController
{
    // GET: api/User/UpdateUserProfile
    [HttpPut("UpdateUserProfile")]
    public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileModel model)
    {
        try
        {
            // Find the user by their ID
            var user = await userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                // Handle user not found
                var userErrorMessage = $"User not found with ID: {model.UserId}";
                Log(LogLevel.Warning, userErrorMessage);
                return NotFound(new { Message = userErrorMessage });
            }

            // Update the user's properties
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            // Attempt to update the user
            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                // User updated successfully
                var successMessage = $"User '{user.UserName}' profile updated successfully.";
                Log(LogLevel.Information, successMessage);
                return Ok(new { Message = successMessage });
            }

            // Handle error updating user
            var updateUserErrorMessage = $"Failed to update user '{user.UserName}' profile. Errors: {string.Join(", ", result.Errors)}";
            Log(LogLevel.Error, updateUserErrorMessage);
            return BadRequest(new { Errors = new[] { "Failed to update user profile." } });
        }
        catch (Exception ex)
        {
            // If an exception occurs, log the error and return a 500 Internal Server Error response
            Log(LogLevel.Error, $"An error occurred while updating the user profile: {ex.Message}");
            return StatusCode(500, "An error occurred while updating the user profile.");
        }
    }
}