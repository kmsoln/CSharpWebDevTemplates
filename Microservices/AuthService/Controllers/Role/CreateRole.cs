using AuthService.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.Role;

public partial class RoleController
{
    // POST: api/Role/CreateRole
    [HttpPost("CreateRole")]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleModel model)
    {
        try
        {
            // Create a new role object with the provided roleName
            var newRole = new IdentityRole { Name = model.RoleName };

            // Attempt to create the new role
            var result = await roleManager.CreateAsync(newRole);

            // If creation succeeded, return a 201 Created response
            if (result.Succeeded)
            {
                Log(LogLevel.Information, $"Role '{newRole.Name}' created successfully.");
                return Ok(new { Message = "Role created successfully", RoleId = newRole.Id });
            }

            // If creation failed, log errors, add errors to ModelState, and return a 400 Bad Request response
            Log(LogLevel.Error, $"Failed to create role '{newRole.Name}'. Errors: {string.Join(", ", result.Errors)}");
            ModelState.AddModelError("", "Failed to create the role. Please check the provided information.");
            return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
        catch (Exception ex)
        {
            // If an exception occurs, log the error and return a 500 Internal Server Error response
            Log(LogLevel.Error, $"An error occurred while creating the role: {ex.Message}");
            return StatusCode(500, "An error occurred while creating the role.");
        }
    }
}