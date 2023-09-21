using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-28FHEV5; database = CoreBlogApiDb; integrated security = true; Encrypt=False;");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
