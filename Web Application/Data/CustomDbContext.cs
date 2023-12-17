using Microsoft.EntityFrameworkCore;

namespace Web_Application.Data;

public class CustomDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships, indexes, etc.
        // This method is optional and can be used to further configure the database model.
    }
}