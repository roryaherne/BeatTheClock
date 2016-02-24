namespace BeatTheClock.Migrations
{
    using Models;
    using Models.DBEntities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeatTheClock.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.ApplicationDbContext context)
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
            ApplicationUser user = context.Users.First();

            context.Places.AddOrUpdate(
                p => p.Title,
                new Place { Title = "Table 1", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Place { Title = "Table 2", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Place { Title = "Table 3", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Place { Title = "Table 4", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Place { Title = "Table 5", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Place { Title = "Table 6", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Place { Title = "Table 7", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Place { Title = "Table 8", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Place { Title = "Table 9", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Place { Title = "Table 10", CreatedById = user.Id, DateCreated = DateTime.Now }
                );
        }
    }
}
