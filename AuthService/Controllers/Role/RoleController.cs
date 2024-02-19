using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers.Role;

public partial class RoleController(
    RoleManager<IdentityRole> roleManager,
    ILogger<RoleController> logger
) : Controller;