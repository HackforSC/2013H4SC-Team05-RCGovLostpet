using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstRace
    {
        public int RaceID { get; set; }
        public string RaceDescription { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
