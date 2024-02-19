using AuthService.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.User;

public partial class UserController(UserManager<AppUser> userManager,
    RoleManager<IdentityRole> roleManager,
    ILogger<UserController> logger
) : Controller;