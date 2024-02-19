using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.Role;

public partial class RoleController
{
    // DELETE: api/Role/DeleteRole
    [HttpDelete("DeleteRole")]
    public async Task<IActionResult> DeleteRole(string roleId)
    {
        try
        {
            Log(LogLevel.Information, $"DeleteRole DELETE action called for role ID '{roleId}'.");

            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                Log(LogLevel.Warning, $"Role with ID '{roleId}' not found.");
                return NotFound(new { Message = "Role not found." });
            }

            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                Log(LogLevel.Information, $"Role '{role.Name}' deleted successfully.");
                return Ok(new { Message = "Role deleted successfully." });
            }

            Log(LogLevel.Error, $"Failed to delete role '{role.Name}'. Errors: {string.Join(", ", result.Errors)}");
            ModelState.AddModelError("", "Failed to delete the role. Please try again.");
            return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
        catch (Exception ex)
        {
            Log(LogLevel.Error, $"An error occurred while deleting the role: {ex.Message}");
            return StatusCode(500, "An error occurred while deleting the role.");
        }
    }
}