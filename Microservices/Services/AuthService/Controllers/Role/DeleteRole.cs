using AuthService.Models.Role;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.Role;

public partial class RoleController
{
    // DELETE: api/Role/DeleteRole
    [HttpDelete("DeleteRole")]
    public async Task<IActionResult> DeleteRole([FromBody] DeleteRoleModel model)
    {
        try
        {
            // Log the action entry
            Log(LogLevel.Information, $"DeleteRole DELETE action called for role ID '{model.RoleId}'.");

            // Find the role by its ID
            var role = await roleManager.FindByIdAsync(model.RoleId);
            if (role == null)
            {
                // Log a warning if the role is not found and return a 404 Not Found result
                Log(LogLevel.Warning, $"Role with ID '{model.RoleId}' not found.");
                return NotFound(new { Message = "Role not found." });
            }

            // Attempt to delete the role
            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                // Log success and return a 200 OK response
                Log(LogLevel.Information, $"Role '{role.Name}' deleted successfully.");
                return Ok(new { Message = "Role deleted successfully." });
            }

            // If deletion failed, log errors, add errors to ModelState, and return a 400 Bad Request response
            Log(LogLevel.Error, $"Failed to delete role '{role.Name}'. Errors: {string.Join(", ", result.Errors)}");
            ModelState.AddModelError("", "Failed to delete the role. Please try again.");
            return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
        catch (Exception ex)
        {
            // If an exception occurs, log the error and return a 500 Internal Server Error response
            Log(LogLevel.Error, $"An error occurred while deleting the role: {ex.Message}");
            return StatusCode(500, "An error occurred while deleting the role.");
        }
    }
}