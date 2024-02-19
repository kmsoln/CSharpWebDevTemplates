using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Controllers.Role;

public partial class RoleController
{
    // GET: api/Role/AllRoles
    [HttpGet("AllRoles")]
    [Authorize]
    public async Task<IActionResult> AllRoles()
    {
        try
        {
            // Log the action entry
            Log(LogLevel.Information, "AllRoles GET action called.");

            // Retrieve all roles from the role manager
            var allRoles = await roleManager.Roles.ToListAsync();

            // Return a 200 OK response with the list of roles
            return Ok(allRoles);
        }
        catch (Exception ex)
        {
            // If an exception occurs, log the error and return a 500 Internal Server Error response
            Log(LogLevel.Error, $"An error occurred while retrieving all roles: {ex.Message}");
            return StatusCode(500, "An error occurred while retrieving all roles.");
        }
    }
}