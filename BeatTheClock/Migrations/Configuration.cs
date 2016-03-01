namespace BeatTheClock.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.DBEntities;
    using System;
    using System.Collections.Generic;
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
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.E.g.

            //  context.People.AddOrUpdate(
            //    p => p.FullName,
            //    new Person { FullName = "Andrew Peters" },
            //    new Person { FullName = "Brice Lambson" },
            //    new Person { FullName = "Rowan Miller" }
            //  );


            if (!(context.Users.Any(u => u.UserName == "rory")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "rory" };
                userManager.Create(userToInsert, "Hunter12!");
            }

            ApplicationUser user = context.Users.First();

            context.Places.AddOrUpdate(
                p => p.Title,
                new Place { Title = "Table 1", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 2 },
                new Place { Title = "Table 2", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 4 },
                new Place { Title = "Table 3", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 4 },
                new Place { Title = "Table 4", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 2 },
                new Place { Title = "Table 5", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 6 },
                new Place { Title = "Table 6", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 10 },
                new Place { Title = "Table 7", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 9 },
                new Place { Title = "Table 8", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 8 },
                new Place { Title = "Table 9", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 3 },
                new Place { Title = "Table 10", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 2 }
            );

            context.ProductTypes.AddOrUpdate(p => p.Title,

                new ProductType { Title = "Bier", Description = "Bier ist super!", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductType { Title = "Wein", Description = "Wein ist geil!", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductType { Title = "Cocktail", Description = "Für Frauen!", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductType { Title = "Whiskey", Description = "Whiskey ist super!", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductType { Title = "Likör", Description = "Likör ist gefährlich!", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductType { Title = "Limonade", Description = "Süß", CreatedById = user.Id, DateCreated = DateTime.Now }
            );

            var bierCatId = context.ProductTypes.Where(t => t.Title == "Bier").Select(t => t.ProductTypeId).FirstOrDefault();

            context.OrderStates.AddOrUpdate(o => o.Title,

                new OrderState { Title = "Ordered", Description = "Ordered", CreatedById = user.Id, DateCreated = DateTime.Now },
                new OrderState { Title = "Delivered", Description = "Ordered", CreatedById = user.Id, DateCreated = DateTime.Now },
                new OrderState { Title = "Paid", Description = "Ordered", CreatedById = user.Id, DateCreated = DateTime.Now }
            );

            context.ProductStates.AddOrUpdate(p => p.Title,

                new ProductState { Title = "Active", Description = "Active", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductState { Title = "Inactive", Description = "Inactive", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductState { Title = "Expired", Description = "Expired", CreatedById = user.Id, DateCreated = DateTime.Now }
            );

            int activeProductId = context.ProductStates.Where(s => s.Title == "Active").Select(s => s.ProductStateId).FirstOrDefault();

            context.Units.AddOrUpdate(u => u.Title,
                new Unit { Title = "Milliliter", BasisFactor = 1, ShortName = "ml", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Liter", BasisFactor = 1000, ShortName = "L", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Centiliter", BasisFactor = 10, ShortName = "cl", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Groß", BasisFactor = 500, ShortName = "0.5L", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Klein", BasisFactor = 300, ShortName = "0.3L", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Pfiff", BasisFactor = 200, ShortName = "0.2L", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Achtel", BasisFactor = 125, ShortName = "1/8", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Viertel", BasisFactor = 250, ShortName = "1/4", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Fass", BasisFactor = 80000, ShortName = "Fass", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Große Flasche", BasisFactor = 500, ShortName = "0.5 Fl", CreatedById = user.Id, DateCreated = DateTime.Now }
            );

            int ml = context.Units.Where(u => u.ShortName == "ml").Select(u => u.UnitId).FirstOrDefault();
            int gross = context.Units.Where(u => u.ShortName == "0.5L").Select(u => u.UnitId).FirstOrDefault();
            int klein = context.Units.Where(u => u.ShortName == "0.3L").Select(u => u.UnitId).FirstOrDefault();
            int viertel = context.Units.Where(u => u.ShortName == "1/4").Select(u => u.UnitId).FirstOrDefault();
            int keg = context.Units.Where(u => u.ShortName == "Fass").Select(u => u.UnitId).FirstOrDefault();
            int gFlasche = context.Units.Where(u => u.ShortName == "0.5 Fl").Select(u => u.UnitId).FirstOrDefault();
            List<int> beerServings = new List<int>();
            beerServings.Add(gross);
            beerServings.Add(klein);

            context.SaveChanges();

            Product guinness = new Product
            {
                Title = "Guinness",
                Description = "Ein mild trochene Stout aus Dublin",
                CreatedById = user.Id,
                DateCreated = DateTime.Now,
                ExperationPeriod = 30,
                ProductTypeId = bierCatId,
                ProductStateId = activeProductId,
                StockUnitId = keg,
                ServingUnits = context.Units.Where(u => beerServings.Contains(u.UnitId)).ToList()
            };
            Product marzen = new Product
            {
                Title = "Zipfer Märzen",
                Description = "In Marz gebraut, in September fertig",
                CreatedById = user.Id,
                DateCreated = DateTime.Now,
                ExperationPeriod = 30,
                ProductTypeId = bierCatId,
                ProductStateId = activeProductId,
                StockUnitId = gFlasche,
                ServingUnits = context.Units.Where(u => u.UnitId == gFlasche).ToList()
            };

            Product zipfer = new Product
            {
                Title = "Zipfer",
                Description = "Standard Zipefer Bier",
                CreatedById = user.Id,
                DateCreated = DateTime.Now,
                ExperationPeriod = 30,
                ProductTypeId = bierCatId,
                ProductStateId = activeProductId,
                StockUnitId = keg,
                ServingUnits = context.Units.Where(u => beerServings.Contains(u.UnitId)).ToList()
            };

            context.Products.AddOrUpdate(p => p.Title, guinness, marzen, zipfer);

            context.SaveChanges();

            context.Orders.AddOrUpdate(o => o.Amount, 
                new Order
                {
                    Amount = 2,
                    OrderedById = user.Id,
                    OrderStateId = context.OrderStates.Where(s => s.Description == "Ordered").Select(s => s.OrderStateId).FirstOrDefault(),
                    OrderTime = DateTime.Now,
                    PlaceId = context.Places.Where(p => p.Title == "Table 6").Select(p => p.PlaceId).FirstOrDefault(),
                    ProductId = guinness.ProductId,
                    UnitId = gross,
                    UnitPrice = 4.50
                },
                new Order
                {
                    Amount = 1,
                    OrderedById = user.Id,
                    OrderStateId = context.OrderStates.Where(s => s.Description == "Ordered").Select(s => s.OrderStateId).FirstOrDefault(),
                    OrderTime = DateTime.Now,
                    PlaceId = context.Places.Where(p => p.Title == "Table 6").Select(p => p.PlaceId).FirstOrDefault(),
                    ProductId = zipfer.ProductId,
                    UnitId = klein,
                    UnitPrice = 3.00
                }
                );

           context.SaveChanges();
        }
    }
}
