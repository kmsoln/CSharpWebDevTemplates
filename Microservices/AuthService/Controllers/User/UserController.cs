using AuthService.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.User;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public partial class UserController(UserManager<AppUser> userManager,
    RoleManager<IdentityRole> roleManager,
    ILogger<UserController> logger
) : Controller;