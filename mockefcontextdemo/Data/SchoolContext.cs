using Microsoft.EntityFrameworkCore;
using mockefcontextdemo.Models;


namespace mockefcontextdemo.Data
{
    public class SchoolContext : DbContext, ISchoolContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=School;Trusted_Connection=True;TrustServerCertificate=Yes");
        }
    }
}
