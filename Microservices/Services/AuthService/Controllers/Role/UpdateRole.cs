using AuthService.Models.Role;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.Role;

public partial class RoleController
{
    // PUT: api/Role/UpdateRole
    [HttpPut("UpdateRole")]
    public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleModel model)
    {
        try
        {
            // Log the action entry
            Log(LogLevel.Information, $"UpdateRole PUT action called for role ID '{model.RoleId}'.");

            // Find the role by its ID
            var role = await roleManager.FindByIdAsync(model.RoleId);
            if (role == null)
            {
                // If role not found, log a warning and return a 404 Not Found result
                Log(LogLevel.Warning, $"Role with ID '{model.RoleId}' not found.");
                return NotFound(new { Message = "Role not found." });
            }

            // Update the role name
            role.Name = model.NewRoleName;

            // Attempt to update the role
            var result = await roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                // If update succeeded, log success and return a 200 OK response
                Log(LogLevel.Information, $"Role '{role.Name}' updated successfully.");
                return Ok(new { Message = "Role updated successfully." });
            }

            // If update failed, log errors, add errors to ModelState, and return a 400 Bad Request response
            Log(LogLevel.Error, $"Failed to update role '{role.Name}'. Errors: {string.Join(", ", result.Errors)}");
            ModelState.AddModelError("", "Failed to update the role. Please check the provided information.");
            return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
        catch (Exception ex)
        {
            // If an exception occurs, log the error and return a 500 Internal Server Error response
            Log(LogLevel.Error, $"An error occurred while updating the role: {ex.Message}");
            return StatusCode(500, "An error occurred while updating the role.");
        }
    }
}