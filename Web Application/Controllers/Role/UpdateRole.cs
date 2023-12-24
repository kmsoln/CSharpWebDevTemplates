using Microsoft.AspNetCore.Mvc;

namespace Web_Application.Controllers.Role;

public partial class RoleController
{
    
    [HttpPost]
    public async Task<IActionResult> UpdateRole(string roleId, string newRoleName)
    {
        try
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                _logger.LogWarning($"Role with ID '{roleId}' not found.");
                return NotFound();
            }

            role.Name = newRoleName;

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                _logger.LogInformation($"Role '{role.Name}' updated successfully.");
                return RedirectToAction("ManageRoles");
            }

            _logger.LogError($"Failed to update role '{role.Name}'. Errors: {string.Join(", ", result.Errors)}");
            ModelState.AddModelError("", "Failed to update the role. Please check the provided information.");
            return View("ManageRoles");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating the role.");
            return StatusCode(500, "An error occurred while updating the role.");
        }
    }
}