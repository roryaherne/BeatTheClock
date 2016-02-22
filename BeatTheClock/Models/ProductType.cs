using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeatTheClock.Models
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string Title { get; set; }

        //navigation properties
        public virtual ICollection<Product> Products { get; set; }
    }
}