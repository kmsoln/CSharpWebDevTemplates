using Microsoft.AspNetCore.Mvc;

namespace Web_Application.Controllers.Role;

public partial class RoleController 
{
    
    [HttpPost]
    public async Task<IActionResult> DeleteRole(string roleId)
    {
        var role = await _roleManager.FindByIdAsync(roleId);

        if (role == null)
        {
            // Role not found
            return NotFound("Role not exists");
        }

        var result = await _roleManager.DeleteAsync(role);

        if (result.Succeeded)
        {
            // Role deletion successful, return no content
            return RedirectToAction("ManageRoles");
        }

        // Role deletion failed, return errors
        return BadRequest(result.Errors);
        
    }
}