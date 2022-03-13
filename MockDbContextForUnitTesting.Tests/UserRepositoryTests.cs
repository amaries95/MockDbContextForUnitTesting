using Microsoft.EntityFrameworkCore;
using MockDbContextForUnitTesting.Api.MockDbContextForUnitTesting.Data;
using MockDbContextForUnitTesting.Api.MockDbContextForUnitTesting.Data.Repositories;
using MockDbContextForUnitTesting.Api.MockDbContextForUnitTesting.Domain.Entities;
using Moq;
using Xunit;

namespace MockDbContextForUnitTesting.Tests
{
    public class UserRepositoryTest
    {
        [Fact]
        public void GetUserById()
        {
            var users = new List<User>
            {
                new User {Id = 0, Name = "Alex", Email = "bla@mail.com"},
                new User {Id = 1, Name = "Alexandra", Email = "bla@mail.com"}
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<User>>();
            mockDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            var options = new DbContextOptionsBuilder<ProjectProjectDbContext>()
                .UseInMemoryDatabase(databaseName: "Products Test")
                .Options;

            var mockProjectDbContext = new Mock<ProjectProjectDbContext>(options);
            mockProjectDbContext.Setup(c => c.Users).Returns(mockDbSet.Object);

            var repo = new UserRepository(mockProjectDbContext.Object);
            var result = repo.GetUserById(1);
        }
    }
}