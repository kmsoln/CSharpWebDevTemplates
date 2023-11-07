using Microsoft.AspNetCore.Mvc;

namespace Web_Application.Controllers;

public class AccountController : Controller
{
    public AccountController() { }

    public IActionResult Login()
    {
        return View();
    }
    
}