using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstFacility
    {
        public int FacilityID { get; set; }
        public string FacilityName { get; set; }
        public string FacilityAddressNumber { get; set; }
        public string FacilityAddressStreet { get; set; }
        public Nullable<int> FacilityCity { get; set; }
        public string FacilityState { get; set; }
        public Nullable<int> FacilityZip { get; set; }
        public Nullable<int> FacilityPlusFour { get; set; }
        public Nullable<decimal> PerAnimalCostOne { get; set; }
        public Nullable<decimal> PerAnimalCostTwo { get; set; }
        public Nullable<decimal> EuthanizeCost { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
