using System.Data.Entity;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.Infrastructure.DataBaseContext
{
    public class ProjectTemplateDbContext : DbContext
    {
        //TODO try to configure connection string name using IoC
        public ProjectTemplateDbContext()
            : base(nameOrConnectionString:"name=DefaultConnection")
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}