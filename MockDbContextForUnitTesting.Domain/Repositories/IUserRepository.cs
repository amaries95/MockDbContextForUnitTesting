using MockDbContextForUnitTesting.Api.MockDbContextForUnitTesting.Domain.Entities;

namespace MockDbContextForUnitTesting.Api.MockDbContextForUnitTesting.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);

        void AddNewUser(User user);
    }
}
