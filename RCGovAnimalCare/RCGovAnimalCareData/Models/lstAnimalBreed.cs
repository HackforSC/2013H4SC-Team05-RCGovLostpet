using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstAnimalBreed
    {
        public int AnimalBreedID { get; set; }
        public string AnimalBreedDescription { get; set; }
        public Nullable<int> AnimalTypeID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
