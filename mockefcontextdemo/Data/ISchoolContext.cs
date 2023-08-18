using Microsoft.EntityFrameworkCore;
using mockefcontextdemo.Models;

namespace mockefcontextdemo.Data
{
    public interface ISchoolContext
    {
        DbSet<Course> Courses { get; set; }
        DbSet<Student> Students { get; set; }
    }
}