using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.Account;

public partial class AccountController
{
    // POST: api/Account/Logout
    [HttpPost("Logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        // Log the logout attempt
        Log(LogLevel.Information, "Logout POST action called.");

        // Sign out the currently authenticated user
        await signInManager.SignOutAsync();

        // Return a 200 OK response or another appropriate status for successful logout
        Log(LogLevel.Information, "User logged out successfully.");
        return Ok(new { Message = "Logout successful." });
    }
}