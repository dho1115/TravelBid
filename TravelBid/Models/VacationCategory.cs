﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBid.Models
{
    public class VacationCategory
    {
        public string CategoryName { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }

        public ICollection<VacationerModel> VacationModels { get; set; }
        public VacationCategory()
        {
            this.VacationModels = new HashSet<VacationerModel>();
        }
    }
}
