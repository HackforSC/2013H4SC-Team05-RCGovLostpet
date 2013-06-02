using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class AnimalPickup
    {
        public int AnimalID { get; set; }
        public string ShelterID { get; set; }
        public Nullable<int> FacilityID { get; set; }
        public Nullable<int> AnimalTypeID { get; set; }
        public Nullable<int> OfficerID { get; set; }
        public Nullable<int> ZoneID { get; set; }
        public Nullable<System.DateTime> DatePickedUp { get; set; }
        public string PickUpAddressNumber { get; set; }
        public string PickUpAddressStreet { get; set; }
        public Nullable<int> CityID { get; set; }
        public string PickUpState { get; set; }
        public string PickUpZip { get; set; }
        public string PickUpPlusFour { get; set; }
        public string Comments { get; set; }
        public Nullable<int> AnimalBreedID { get; set; }
        public Nullable<int> AnimalSizeID { get; set; }
        public Nullable<System.DateTime> DateLicensed { get; set; }
        public Nullable<int> HoldDays { get; set; }
        public Nullable<System.DateTime> DateTransported { get; set; }
        public Nullable<int> StatusInd { get; set; }
        public Nullable<int> AnimalSexID { get; set; }
        public Nullable<int> AnimalColorID { get; set; }
        public Nullable<int> OwnerID { get; set; }
        public Nullable<int> CitationID { get; set; }
        public string PenNumber { get; set; }
        public Nullable<bool> LicensedInd { get; set; }
        public Nullable<bool> QuarantinedInd { get; set; }
        public string PhotoName { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateLastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
