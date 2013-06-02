using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstUser
    {
        public int UserID { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserGUID { get; set; }
        public string UserName { get; set; }
        public Nullable<int> UserSecurityLevel { get; set; }
        public Nullable<bool> StatusID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
