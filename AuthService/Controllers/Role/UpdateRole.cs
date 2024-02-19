using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.Role;

public partial class RoleController
{
    // PUT: api/Role/UpdateRole
    [HttpPut("UpdateRole")]
    public async Task<IActionResult> UpdateRole(string roleId, string newRoleName)
    {
        try
        {
            Log(LogLevel.Information, $"UpdateRole PUT action called for role ID '{roleId}'.");

            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                Log(LogLevel.Warning, $"Role with ID '{roleId}' not found.");
                return NotFound(new { Message = "Role not found." });
            }

            role.Name = newRoleName;

            var result = await roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                Log(LogLevel.Information, $"Role '{role.Name}' updated successfully.");
                return Ok(new { Message = "Role updated successfully." });
            }

            Log(LogLevel.Error, $"Failed to update role '{role.Name}'. Errors: {string.Join(", ", result.Errors)}");
            ModelState.AddModelError("", "Failed to update the role. Please check the provided information.");
            return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
        catch (Exception ex)
        {
            Log(LogLevel.Error, $"An error occurred while updating the role: {ex.Message}");
            return StatusCode(500, "An error occurred while updating the role.");
        }
    }
}