using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstCity
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
