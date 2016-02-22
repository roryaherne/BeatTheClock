using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeatTheClock.Models
{
    public class BarContext : DbContext
    {
        public BarContext() : base("DefaultConnection") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
    }
}