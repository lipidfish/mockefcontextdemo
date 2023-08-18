using Microsoft.EntityFrameworkCore;
using mockefcontextdemo.Data;
using mockefcontextdemo.Models;
using Moq;

namespace mockefcontextdemo.Tests
{
    public class MockDbContextBuilder
    {
        protected readonly Mock<ISchoolContext> _mockDbContext;

        public MockDbContextBuilder()
        {
            _mockDbContext = new Mock<ISchoolContext>();
        }

        public MockDbContextBuilder WithStudents(List<Student> students)
        {
            _mockDbContext.Setup(m => m.Students).Returns(BuildMockDbSet(students));
            return this;
        }

        public Mock<ISchoolContext> Build()
    => _mockDbContext;

        protected static DbSet<TEntity> BuildMockDbSet<TEntity>(List<TEntity> sourceList) where TEntity : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<TEntity>>();
            dbSet.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<TEntity>(queryable.Provider));
            dbSet.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<TEntity>())).Callback<TEntity>((s) => sourceList.Add(s));

            return dbSet.Object;
        }


    }
}
