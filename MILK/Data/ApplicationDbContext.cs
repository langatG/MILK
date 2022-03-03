using Microsoft.EntityFrameworkCore;
using MILK.Model;

namespace MILK.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Farmer> Farmer { get; set; }
    }
}
