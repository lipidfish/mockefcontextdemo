using FluentAssertions;
using mockefcontextdemo.Models;
using mockefcontextdemo.Services;

namespace mockefcontextdemo.Tests
{
    public class SchoolServiceTests
    {
        [Fact]
        public async Task Test1()
        {

            var student1 = new Student { StudentId = 1, Name = "Luke Skywalker" };
            var student2 = new Student { StudentId = 2, Name = "Han Solo" };

            var mockStudentList = new List<Student> {
                student1,
                student2
            };

            var mockDbContext = new MockDbContextBuilder().WithStudents(mockStudentList).Build();

            var service = new SchoolService(mockDbContext.Object);
            var actual = await service.GetStudentById(1);

            actual.Should().BeEquivalentTo(student1);

        }
    }
}