using System;
using System.Collections.Generic;

namespace SawgrassViewerApi.Models
{
    public partial class ClaimXref
    {
        public string PolicyId { get; set; }
        public string ClaimId { get; set; }
        public string DocType { get; set; }
        public string AmazonS32ref { get; set; }
    }
}
