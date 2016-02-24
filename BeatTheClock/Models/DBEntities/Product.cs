﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeatTheClock.Models.DBEntities
{
    public class Product
    {
        public int ProductId { get; set; }

        [StringLength(128, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }

        [StringLength(512, MinimumLength = 1)]
        public string Description { get; set; }

        public TimeSpan ExperationPeriod { get; set; }

        public byte[] Image { get; set; }

        //navigation properties
        public int StockUnitId { get; set; }
        public string CreatedById { get; set; }
        public int ProductStateId { get; set; }
        public int ProductTypeId { get; set; }

        public virtual Unit StockUnit { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ProductState ProductState { get; set; }
        public virtual ProductType ProductType { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}