using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstAnimalType
    {
        public int AnimalTypeID { get; set; }
        public string AnimalTypeDescription { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
