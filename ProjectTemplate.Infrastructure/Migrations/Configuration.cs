using System.Web.Security;
using ProjectTemplate.Infrastructure.DataBaseContext;
using WebMatrix.WebData;

namespace ProjectTemplate.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectTemplateDbContext>
    {
        private const string AdministratorRole = "Administrator";
        private const string UserRole = "User";
        private const string Email = "a.kovalenko@mail.com";
        private const string Password = "qweqwe";
        private const string FirstName = "Andrew";
        private const string LastName = "Kovalenko";

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectTemplateDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            WebSecurity.InitializeDatabaseConnection(connectionStringName: "DefaultConnection", userTableName: "Users", userIdColumn: "Id", userNameColumn: "Email", autoCreateTables: true);

            Roles.CreateRole(AdministratorRole);
            Roles.CreateRole(UserRole);

            WebSecurity.CreateUserAndAccount(Email, Password,
                                             new
                                             {
                                                 CreatedAt = DateTime.Now,
                                                 UpdatedAt = DateTime.Now,
                                                 FirstName = FirstName,
                                                 LastName = LastName
                                             });

            Roles.AddUserToRole(Email, AdministratorRole);
            
        }
    }
}
