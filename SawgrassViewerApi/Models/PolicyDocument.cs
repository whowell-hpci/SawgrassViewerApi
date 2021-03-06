﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawgrassViewerApi.Models
{
    public class PolicyDocument
    {
        public string Url { get; set; }
        public string NamedInsured { get; set; }
        public string PolicyNumber { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string DocType { get; set; }
    }
}
