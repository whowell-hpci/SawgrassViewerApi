using SawgrassViewerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawgrassViewerApi.Repositories
{
    public interface IPolicyRepository
    {
        List<PolicyDocument> GetPolicyDocumentsByPolicyNumber(string policyNumber);
        Policy GetInsuredNameByPolicyNumber(string policyNumber);
    }
}
