using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeatTheClock.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Title { get; set; }

        //navigation properties
        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Category")]
        public virtual ProductType ProductType { get; set; }

    }
}