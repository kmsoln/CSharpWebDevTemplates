using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models.User;

namespace MVC.Controllers.User;

public partial class UserController
{
    public async Task<IActionResult> ManageUsers()
    {
        var users = await _userManager.Users.ToListAsync();

        // Retrieve user roles asynchronously
        var usersRoles = new Dictionary<string, List<string>>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            usersRoles[user.Id] = roles.ToList();
        }

        var model = new ManageUsersViewModel
        {
            Users = users,
            UserRoles = usersRoles
        };

        return View(model);
    }
}