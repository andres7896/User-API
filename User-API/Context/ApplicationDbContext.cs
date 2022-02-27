using User_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace User_API.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; } = null!;
    }
}
