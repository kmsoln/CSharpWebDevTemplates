using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.User;

public partial class UserController
{
    // DELETE: api/User/DeleteUserProfile
    [HttpDelete("DeleteUserProfile")]
    public async Task<IActionResult> DeleteUserProfile(string userId)
    {
        try
        {
            // Find the user by ID
            var user = await userManager.FindByIdAsync(userId);

            // If user not found, return a 404 Not Found response
            if (user == null)
            {
                Log(LogLevel.Warning, $"User with ID '{userId}' not found.");
                return NotFound(new { Message = "User not found." });
            }

            // Attempt to delete the user
            var result = await userManager.DeleteAsync(user);

            // If deletion succeeded, return a 204 No Content response
            if (result.Succeeded)
            {
                Log(LogLevel.Information, $"User '{user.UserName}' deleted successfully.");
                return NoContent();
            }

            // If deletion failed, log errors, add errors to ModelState, and return a 400 Bad Request response
            Log(LogLevel.Error, $"Failed to delete user '{user.UserName}'. Errors: {string.Join(", ", result.Errors)}");
            ModelState.AddModelError("", "Failed to delete the user. Please try again.");
            return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
        catch (Exception ex)
        {
            // If an exception occurs, log the error and return a 500 Internal Server Error response
            Log(LogLevel.Error, $"An error occurred while deleting the user: {ex.Message}");
            return StatusCode(500, "An error occurred while deleting the user.");
        }
    }

}