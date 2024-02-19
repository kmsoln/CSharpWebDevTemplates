using MVC.Auth;

namespace MVC.Models.User;

public class ManageUsersViewModel
{
    public List<AppUser>? Users { get; set; }
    public Dictionary<string, List<string>>? UserRoles { get; set; }
}