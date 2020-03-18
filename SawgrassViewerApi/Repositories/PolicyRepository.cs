using Microsoft.EntityFrameworkCore;
using SawgrassViewerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SawgrassViewerApi.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly SawgrassLegacyDocLookupContext _context;

        public PolicyRepository(SawgrassLegacyDocLookupContext context)
        {
            _context = context;
        }
        public List<PolicyDocument> GetPolicyDocumentsByPolicyNumber(string policyNumber)
        {
            List<PolicyDocument> returnedDocs = _context.PolicyXref.Where(x => x.Policy == policyNumber).Select(p => new PolicyDocument
            {
                PolicyNumber = p.Policy,
                DocType = p.DocType,
                Url = p.AmazonS3ref
            }).ToList();


            return returnedDocs;
            
        }

        public Policy GetInsuredNameByPolicyNumber(string policyNumber)
        {
            var data = _context.PolicyMaster.FirstOrDefault(p => p.PolicyId == policyNumber);
            Policy policy = new Policy();
            policy.PolicyNumber = data.PolicyId;
            policy.InsuredName = data.InsuredName;

            var docs = GetPolicyDocumentsByPolicyNumber(policyNumber).ToArray();
            policy.Documents = docs;


            return policy;
        }

    }
}
