using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web_Application.Controllers.Role;

public partial class RoleController 
{
    
    [HttpPost]
    public async Task<IActionResult> CreateRole(string roleName)
    {
        try
        {
            var newRole = new IdentityRole { Name = roleName };

            var result = await _roleManager.CreateAsync(newRole);

            if (result.Succeeded)
            {
                _logger.LogInformation($"Role '{newRole.Name}' created successfully.");
                return RedirectToAction("ManageRoles");
            }

            _logger.LogError($"Failed to create role '{newRole.Name}'. Errors: {string.Join(", ", result.Errors)}");
            ModelState.AddModelError("", "Failed to create the role. Please check the provided information.");
            return View("ManageRoles");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating the role.");
            return StatusCode(500, "An error occurred while creating the role.");
        }
    }
}