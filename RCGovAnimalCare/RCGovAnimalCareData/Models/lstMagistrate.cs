using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstMagistrate
    {
        public int MagistrateID { get; set; }
        public string MagistrateName { get; set; }
        public string MagistrateAddressNumber { get; set; }
        public string MagistrateAddressStreet { get; set; }
        public Nullable<int> MagistrateCity { get; set; }
        public string StateID { get; set; }
        public Nullable<int> MagistrateZip { get; set; }
        public Nullable<int> MagistratePlusFour { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
