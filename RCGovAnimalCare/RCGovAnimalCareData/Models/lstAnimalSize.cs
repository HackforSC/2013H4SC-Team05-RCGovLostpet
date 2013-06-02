using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstAnimalSize
    {
        public int AnimalSizeID { get; set; }
        public string AnimalSizeDescription { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateLastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
