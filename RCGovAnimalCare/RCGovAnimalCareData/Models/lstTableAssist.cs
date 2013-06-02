using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstTableAssist
    {
        public int AssistID { get; set; }
        public Nullable<int> TableID { get; set; }
        public Nullable<int> TableKey { get; set; }
        public string AssistTable { get; set; }
    }
}
