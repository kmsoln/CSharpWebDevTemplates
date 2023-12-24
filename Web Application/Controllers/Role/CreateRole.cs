using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web_Application.Models.Role;

namespace Web_Application.Controllers.Role;

public partial class RoleController 
{
    
        [HttpPost]
        // Endpoint to create a new role
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var newRole = new IdentityRole { Name = roleName };

            var result = await _roleManager.CreateAsync(newRole);

            if (result.Succeeded)
            {
                // Role creation successful, return the created role
                return RedirectToAction("ManageRoles");
            }

            // Role creation failed, return errors
            return BadRequest(result.Errors);
        }
}