using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstOrdinance
    {
        public int OrdinanceID { get; set; }
        public string OrdinanceDescription { get; set; }
        public string OrdinanceType { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
