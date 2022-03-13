using MockDbContextForUnitTesting.Api.MockDbContextForUnitTesting.Domain.Entities;
using MockDbContextForUnitTesting.Api.MockDbContextForUnitTesting.Domain.Repositories;

namespace MockDbContextForUnitTesting.Api.MockDbContextForUnitTesting.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectProjectDbContext _projectProjectDbContext;

        public UserRepository(ProjectProjectDbContext projectProjectDbContext)
        {
            _projectProjectDbContext = projectProjectDbContext;
        }

        public User GetUserById(int id)
        {
            return _projectProjectDbContext.Users.SingleOrDefault(x => x.Id == id);
        }

        public void AddNewUser(User user)
        {
            _projectProjectDbContext.Users.Add(
                new User
                {
                    Name = user.Name,
                    Email = user.Email
                });
            _projectProjectDbContext.SaveChanges();
        }
    }
}
