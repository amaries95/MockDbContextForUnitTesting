using Microsoft.EntityFrameworkCore;
using MockDbContextForUnitTesting.Api.MockDbContextForUnitTesting.Domain.Entities;

namespace MockDbContextForUnitTesting.Api.MockDbContextForUnitTesting.Data
{
    public class ProjectProjectDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public ProjectProjectDbContext(DbContextOptions<ProjectProjectDbContext> options) : base(options) { }
    }
}
