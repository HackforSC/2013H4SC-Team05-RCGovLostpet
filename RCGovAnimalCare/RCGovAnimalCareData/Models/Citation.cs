using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class Citation
    {
        public int CitationID { get; set; }
        public Nullable<int> OffenderID { get; set; }
        public Nullable<int> MagistrateID { get; set; }
        public string CitationNumber { get; set; }
        public Nullable<System.DateTime> CourtDate { get; set; }
        public string CourtTimeHr { get; set; }
        public string CourtTimeMin { get; set; }
        public Nullable<bool> CourtTimeInd { get; set; }
        public string CourtRoomNumber { get; set; }
        public Nullable<int> OrdinanceID { get; set; }
        public Nullable<System.DateTime> CitationDate { get; set; }
        public string CitationTimeHr { get; set; }
        public string CitationTimeMin { get; set; }
        public Nullable<bool> CitationTimeInd { get; set; }
        public string CitationLocationNumber { get; set; }
        public string CitationLocationStreet { get; set; }
        public Nullable<System.DateTime> ViolationDate { get; set; }
        public string ViolationTimeHr { get; set; }
        public string ViolationTimeMin { get; set; }
        public Nullable<bool> ViolationTimeInd { get; set; }
        public string ViolationLocationNumber { get; set; }
        public string ViolationLocationStreet { get; set; }
        public Nullable<int> OfficerID { get; set; }
        public Nullable<decimal> BondAmmount { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateLastModified { get; set; }
        public string ModifiedBy { get; set; }
        //added comments for testing 
    }
}
