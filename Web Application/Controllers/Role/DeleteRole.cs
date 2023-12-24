using Microsoft.AspNetCore.Mvc;

namespace Web_Application.Controllers.Role;

public partial class RoleController 
{
    
    [HttpPost]
    public async Task<IActionResult> DeleteRole(string roleId)
    {
        try
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                _logger.LogWarning($"Role with ID '{roleId}' not found.");
                return NotFound("Role not exists");
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                _logger.LogInformation($"Role '{role.Name}' deleted successfully.");
                return RedirectToAction("ManageRoles");
            }

            _logger.LogError($"Failed to delete role '{role.Name}'. Errors: {string.Join(", ", result.Errors)}");
            ModelState.AddModelError("", "Failed to delete the role. Please try again.");
            return View("ManageRoles"); // Replace "ManageRoles" with your actual view name for role management
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting the role.");
            return StatusCode(500, "An error occurred while deleting the role.");
        }
    }
}