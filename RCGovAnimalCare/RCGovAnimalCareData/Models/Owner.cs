using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class Owner
    {
        public int OwnerID { get; set; }
        public string OwnerName { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerCity { get; set; }
        public string StateID { get; set; }
        public string OwnerZip { get; set; }
        public string OwnerPlusFour { get; set; }
        public string OwnerPhoneAreaCode { get; set; }
        public string OwnerPhonePrefix { get; set; }
        public string OwnerPhoneSuffix { get; set; }
        public string OwnerDriverLicenseState { get; set; }
        public string OwnerDriverLicenseNumber { get; set; }
        public Nullable<bool> TurnedinInd { get; set; }
        public Nullable<bool> RedeemedInd { get; set; }
        public Nullable<System.DateTime> DateRedeemed { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
