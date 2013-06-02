using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstZone
    {
        public int ZoneID { get; set; }
        public string ZoneDescription { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
