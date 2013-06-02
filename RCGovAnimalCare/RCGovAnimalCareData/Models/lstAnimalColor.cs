using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstAnimalColor
    {
        public int AnimalColorID { get; set; }
        public string AnimalColorDescription { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
