using AuthService.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.Account;

[ApiController]
[Route("api/[controller]")]
public partial class AccountController(
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager,
    ILogger<AccountController> logger
) : Controller;