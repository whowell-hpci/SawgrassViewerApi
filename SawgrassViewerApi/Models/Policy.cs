using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawgrassViewerApi.Models
{
    public class Policy
    {
        public string PolicyNumber { get; set; }
        public string InsuredName { get; set; }

        public PolicyDocument[] Documents { get; set; }
        public PolicyClaimDocument[] Claims { get; set; }
    }
}
