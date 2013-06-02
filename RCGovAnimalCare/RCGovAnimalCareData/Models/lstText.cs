using System;
using System.Collections.Generic;

namespace RCGovAnimalCareData.Models
{
    public partial class lstText
    {
        public int TextID { get; set; }
        public string TextHeader { get; set; }
        public Nullable<int> TextHeaderFontsize { get; set; }
        public string TextBody { get; set; }
        public Nullable<int> TextBodyFontsize { get; set; }
        public string TextFooter { get; set; }
        public Nullable<int> TextFooterFontsize { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
