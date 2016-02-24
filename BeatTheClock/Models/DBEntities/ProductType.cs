using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeatTheClock.Models.DBEntities
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //navigation properties
        public virtual ICollection<Product> Products { get; set; }
    }
}