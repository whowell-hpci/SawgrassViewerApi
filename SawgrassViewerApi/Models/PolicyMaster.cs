using System;
using System.Collections.Generic;

namespace SawgrassViewerApi.Models
{
    public partial class PolicyMaster
    {
        public string PolicyId { get; set; }
        public string InsuredName { get; set; }
        public DateTime? EffDate { get; set; }
        public DateTime? ExpDate { get; set; }
    }
}
