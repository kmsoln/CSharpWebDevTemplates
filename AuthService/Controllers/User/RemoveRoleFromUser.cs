using AuthService.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.User;

public partial class UserController
{
    // DELETE: api/User/RemoveRoleFromUser
    [HttpDelete("RemoveRoleFromUser")]
    public async Task<IActionResult> RemoveRoleFromUser([FromBody] RemoveRoleFromUserModel model)
    {
        try
        {
            // Find the user by ID
            var user = await userManager.FindByIdAsync(model.UserId);

            // If user not found, return a 404 Not Found response
            if (user == null)
            {
                var userErrorMessage = $"User not found with ID: {model.UserId}";
                Log(LogLevel.Warning, userErrorMessage);
                return NotFound(new { Message = userErrorMessage });
            }

            // Check if the role exists
            var roleExists = await roleManager.RoleExistsAsync(model.RoleName);

            // If role does not exist, return a 400 Bad Request response
            if (!roleExists)
                return BadRequest(new { Errors = new[] { "Role does not exist." } });

            // Remove the role from the user
            var result = await userManager.RemoveFromRoleAsync(user, model.RoleName);

            // If role removal succeeded, return a 200 OK response with the updated user roles
            if (result.Succeeded)
            {
                var updatedUserRoles = await userManager.GetRolesAsync(user);

                var successMessage = $"Role '{model.RoleName}' removed from user '{user.UserName}' successfully.";
                Log(LogLevel.Information, successMessage);

                return Ok(new { Message = successMessage, UserRoles = updatedUserRoles });
            }

            // If role removal failed, log the error and return a 400 Bad Request response
            var removeRoleErrorMessage =
                $"Failed to remove role '{model.RoleName}' from user '{user.UserName}'. Errors: {string.Join(", ", result.Errors)}";
            Log(LogLevel.Error, removeRoleErrorMessage);
            return BadRequest(new { Errors = new[] { "Failed to remove role." } });
        }
        catch (Exception ex)
        {
            // If an exception occurs, log the error and return a 500 Internal Server Error response
            Log(LogLevel.Error, $"An error occurred while removing role: {ex.Message}");
            return StatusCode(500, "An error occurred while removing role.");
        }
    }
}