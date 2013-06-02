using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstAnimalSex
    {
        public int AnimalSexID { get; set; }
        public string AnimalSexDescription { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
