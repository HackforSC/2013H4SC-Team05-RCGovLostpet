using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstTable
    {
        public int TableID { get; set; }
        public string Tablename { get; set; }
        public string DisplayName { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string Modifiedby { get; set; }
    }
}
