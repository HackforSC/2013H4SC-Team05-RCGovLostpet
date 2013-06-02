using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstStatu
    {
        public int StatusID { get; set; }
        public string StatusDescription { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
