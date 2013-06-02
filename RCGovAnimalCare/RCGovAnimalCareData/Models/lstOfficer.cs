using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstOfficer
    {
        public int OfficerID { get; set; }
        public string OfficerName { get; set; }
        public string OfficerBadgeNumber { get; set; }
        public Nullable<bool> StatusInd { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
