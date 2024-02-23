using AuthService.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.User;

public partial class UserController
{
    // POST: api/User/AddRoleToUser
    [HttpPost("AddRoleToUser")]
    public async Task<IActionResult> AddRoleToUser([FromBody] AddRoleToUserModel model)
    {
        try
        {
            // Validate the incoming model
            if (model == null || string.IsNullOrEmpty(model.UserId) || string.IsNullOrEmpty(model.RoleName))
            {
                return BadRequest(new { Errors = new[] { "Invalid request model." } });
            }

            // Send a request to the User Management microservice to find the user by ID
            var user = await userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                // Handle user not found
                var userErrorMessage = $"User not found with ID: {model.UserId}";
                Log(LogLevel.Warning, userErrorMessage);
                return NotFound(new { Message = userErrorMessage });
            }

            // Send a request to the Role Management microservice to check if the role exists
            var roleExists = await roleManager.RoleExistsAsync(model.RoleName);

            if (!roleExists)
            {
                // Handle role not found
                return BadRequest(new { Errors = new[] { "Role does not exist." } });
            }

            // Send a request to the User Management microservice to add the role to the user
            var result = await userManager.AddToRoleAsync(user, model.RoleName);

            if (result.Succeeded)
            {
                // Role added successfully

                // Reload user roles after adding a new role
                var updatedUserRoles = await userManager.IsInRoleAsync(user, model.RoleName);

                // Update the model with the new roles
                var successMessage = $"Role '{model.RoleName}' added to user '{user.UserName}' successfully.";
                Log(LogLevel.Information, successMessage);

                // Return a 200 OK response with the updated model
                return Ok(new { Message = successMessage, UserRoles = updatedUserRoles });
            }

            // Handle error adding role
            var addRoleErrorMessage =
                $"Failed to add role '{model.RoleName}' to user '{user.UserName}'. Errors: {string.Join(", ", result.Errors)}";
            Log(LogLevel.Error, addRoleErrorMessage);
            return BadRequest(new { Errors = new[] { "Failed to add role." } });
        }
        catch (Exception ex)
        {
            // Log and handle any exceptions that occur
            Log(LogLevel.Error, $"An error occurred while adding role to user: {ex.Message}");
            return StatusCode(500, new { Message = "An error occurred while adding role to user." });
        }
    }
}