using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;

namespace MyWebAPI.Context
{
    public class ApplicationDbContext:DbContext {
        
        // constructor 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}
