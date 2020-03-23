using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawgrassViewerApi.Models
{
    public class PolicyClaimDocument
    {
        public string PolicyId { get; set; }
        public string DocType { get; set; }
        public string Url { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string ClaimId { get; set; }

    }
}
