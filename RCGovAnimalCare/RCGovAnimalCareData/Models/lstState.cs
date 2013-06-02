using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstState
    {
        public string StateID { get; set; }
        public string StateName { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
