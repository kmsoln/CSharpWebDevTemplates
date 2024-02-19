using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Auth;

namespace MVC.Controllers.User;

public partial class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly RoleManager<IdentityRole> _roleManager;

    private readonly UserManager<AppUser> _userManager;

    public UserController(
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ILogger<UserController> logger)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _logger = logger;
    }
}