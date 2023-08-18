using Microsoft.EntityFrameworkCore;
using mockefcontextdemo.Data;
using mockefcontextdemo.Models;

namespace mockefcontextdemo.Services
{
    public class SchoolService
    {
        private readonly ISchoolContext _schoolContext;

        public SchoolService(ISchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public Task<Student> GetStudentById(int id)
        {
            return _schoolContext.Students.SingleAsync(x => x.StudentId == id);
        }

    }
}
