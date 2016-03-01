using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeatTheClock.Models.DBEntities
{
    public class Place
    {
        public Place()
        {
            Orders = new List<Order>();
        }
        public int PlaceId { get; set; }

        [StringLength(255, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Seats")]
        public int Capacity { get; set; }

        //foreign keys
        [Required]
        public string CreatedById { get; set; }

        //navigation properties
        [ForeignKey("CreatedById")]
        public virtual ApplicationUser CreatedBy { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}