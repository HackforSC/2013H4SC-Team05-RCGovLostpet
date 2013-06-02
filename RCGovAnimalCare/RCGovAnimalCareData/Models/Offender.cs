using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class Offender
    {
        public int OffenderID { get; set; }
        public string OffenderName { get; set; }
        public string OffenderAddress { get; set; }
        public string OffenderCity { get; set; }
        public string StateID { get; set; }
        public string OffenderZip { get; set; }
        public string OffenderPlusFour { get; set; }
        public Nullable<System.DateTime> OffenderDateOfBirth { get; set; }
        public Nullable<int> RaceID { get; set; }
        public Nullable<int> OffenderHeightFeet { get; set; }
        public Nullable<int> OffenderHeightInches { get; set; }
        public Nullable<int> OffenderWeight { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
