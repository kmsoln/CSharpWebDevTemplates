using Microsoft.AspNetCore.Mvc;
using Web_Application.Models.Role;

namespace Web_Application.Controllers.Role;

public partial class RoleController
{
    
    [HttpPost]
    public async Task<IActionResult> UpdateRole(string roleId, string newRoleName)
    {
        var role = await _roleManager.FindByIdAsync(roleId);

        if (role == null)
        {
            // Role not found
            return NotFound();
        }

        role.Name = newRoleName;

        var result = await _roleManager.UpdateAsync(role);

        if (result.Succeeded)
        {
            // Role update successful, return the updated role
            return RedirectToAction("ManageRoles");
        }

        // Role update failed, return errors
        return BadRequest(result.Errors);
    }
}