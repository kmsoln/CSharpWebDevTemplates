using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.User;

public partial class UserController
{
    // GET: api/User/GetUserProfile
    [HttpGet("GetUserProfile")]
    public async Task<IActionResult> GetUserProfile(string userId)
    {
        try
        {
            // Find the user by ID
            var user = await userManager.FindByIdAsync(userId);

            // If user not found, log a warning and return NotFound result
            if (user == null)
            {
                Log(LogLevel.Warning, $"User with ID '{userId}' not found.");
                return NotFound(new { Message = "User not found" });
            }

            // Get user roles
            var userRoles = await userManager.GetRolesAsync(user);

            // Create a view model to represent the user profile
            var profileViewModel = new
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Roles = userRoles
            };

            // Log the successful retrieval of the user profile
            Log(LogLevel.Information, $"User profile retrieved successfully for user {user.UserName}.");

            // Return the user profile as JSON
            return Ok(profileViewModel);
        }
        catch (Exception ex)
        {
            // If an exception occurs, log the error and return a 500 Internal Server Error response
            Log(LogLevel.Error, $"An error occurred while retrieving the user profile: {ex.Message}");
            return StatusCode(500, "An error occurred while retrieving the user profile.");
        }
    }

}