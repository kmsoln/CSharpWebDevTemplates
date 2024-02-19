using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.Role;

[Authorize]
// [Authorize(Roles = "admin")]
public partial class RoleController(
    RoleManager<IdentityRole> roleManager,
    ILogger<RoleController> logger
) : Controller;