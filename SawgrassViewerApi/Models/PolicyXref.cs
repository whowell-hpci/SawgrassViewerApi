using System;
using System.Collections.Generic;

namespace SawgrassViewerApi.Models
{
    public partial class PolicyXref
    {
        public string Policy { get; set; }
        public string DocType { get; set; }
        public string AmazonS3ref { get; set; }
    }
}
