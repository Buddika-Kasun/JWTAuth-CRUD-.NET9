using JWTAuthCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthCRUD.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
