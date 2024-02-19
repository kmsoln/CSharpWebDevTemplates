using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Controllers.Role;

public partial class RoleController
{
    [HttpGet("AllRoles")]
    [Authorize]
    public async Task<IActionResult> AllRoles()
    {
        try
        {
            Log(LogLevel.Information, "AllRoles GET action called.");

            var allRoles = await roleManager.Roles.ToListAsync();
            return Ok(allRoles);
        }
        catch (Exception ex)
        {
            Log(LogLevel.Error, $"An error occurred while retrieving all roles: {ex.Message}");
            return StatusCode(500, "An error occurred while retrieving all roles.");
        }
    }
}