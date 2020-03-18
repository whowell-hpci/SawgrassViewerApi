using System;
using System.Collections.Generic;

namespace SawgrassViewerApi.Models
{
    public partial class ClaimMaster
    {
        public string ClaimId { get; set; }
        public DateTime? LossDate { get; set; }
        public DateTime? ReportedDate { get; set; }
        public string PolicyId { get; set; }
        public string InsuredName { get; set; }
        public DateTime? EffDate { get; set; }
        public DateTime? ExpDate { get; set; }
    }
}
