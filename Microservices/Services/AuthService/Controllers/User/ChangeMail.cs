using AuthService.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.User;

public partial class UserController
{
    // PUT: api/Account/ChangeMail
    [Authorize]
    [HttpPut("ChangeMail")]
    public async Task<IActionResult> ChangeMail([FromBody] ChangeMailModel model)
    {
        // Log action entry
        Log(LogLevel.Information, "ChangeMail PUT action called.");

        // Check if the model is valid
        if (ModelState.IsValid)
        {
            // Check if new mail equals confirm email
            if (model.NewEmail != model.ConfirmNewEmail)
                return StatusCode(404, new { Message = "Email and confirmation email do not match." });

            try
            {
                // Retrieve the user from the user manager using the UserId from the model
                var user = await userManager.FindByIdAsync(model.UserId);

                // Check if the user exists
                if (user != null)
                {
                    // Attempt to update the user's email
                    user.Email = model.NewEmail;
                    var result = await userManager.UpdateAsync(user);

                    // Check if the email update was successful
                    if (result.Succeeded)
                    {
                        // Email change successful, return a 200 OK response or another appropriate status
                        Log(LogLevel.Information, $"Email change successful for user {user.UserName}.");
                        return Ok(new { Message = "Email change successful" });
                    }

                    // If there are errors during email update, return a 400 Bad Request with error details
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        Log(LogLevel.Error, $"Error updating user email: {error.Description}");
                    }

                    return BadRequest(new
                        { Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
                }

                // Log the case where the user cannot be found and return a 404 Not Found
                ModelState.AddModelError(string.Empty, "User not found.");
                Log(LogLevel.Error, "User not found during email change.");
                return NotFound(new { Message = "User not found" });
            }
            catch (Exception ex)
            {
                // Log any exceptions that occurred during email update and return a 500 Internal Server Error
                Log(LogLevel.Error, $"An error occurred while updating user email: {ex.Message}");
                return StatusCode(500, new { Message = "Internal Server Error" });
                // Handle other exception details if needed
            }
        }

        // If the model state is not valid, return a 400 Bad Request with error details
        return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
    }
}