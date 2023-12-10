using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_Application.Models.Auth;

namespace Web_Application.Data;

public class MyDbContext : IdentityDbContext<AppUser>
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
}
