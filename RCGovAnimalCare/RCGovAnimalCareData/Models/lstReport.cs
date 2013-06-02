using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstReport
    {
        public int ReportID { get; set; }
        public string DisplayText { get; set; }
        public string ReportPath { get; set; }
        public Nullable<int> ReportSecureLevel { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
