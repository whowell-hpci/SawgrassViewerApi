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

            foreach (var doc in returnedDocs)
            {
                var year = GetYear(doc.Url);
                if (year != "none")
                {
                    doc.Year = GetYear(doc.Url).Substring(0, 4);
                } else
                {
                    doc.Year = "None";
                }
                
            }

            return returnedDocs;
        }

       private static string GetYear(string url)
        {
            string[] words = url.Split('/');
            foreach (var word in words)
            {
                if (word.Length == 6 && word.StartsWith("20"))
                {
                    return word;
                } 
                
            }
            return "None";
        }

        public List<PolicyClaimDocument> GetPolicyClaimsDocumentsByPolicyNumber(string policyNumber)
        {
            List<PolicyClaimDocument> returnedClaims = _context.ClaimXref.Where(x => x.PolicyId == policyNumber).Select(c => new PolicyClaimDocument {
                PolicyId = c.PolicyId,
                ClaimId = c.ClaimId,
                DocType = c.DocType,
                Url = c.AmazonS32ref
            }).ToList();

            foreach (var claim in returnedClaims)
            {
                var year = GetYear(claim.Url);
                if (year != "none")
                {
                    claim.Year = GetYear(claim.Url).Substring(0, 4);
                }
                else
                {
                    claim.Year = "None";
                }

            }

            return returnedClaims;



            return returnedClaims;
        }

            

        public Policy GetInsuredNameByPolicyNumber(string policyNumber)
        {
            var data = _context.PolicyMaster.FirstOrDefault(p => p.PolicyId == policyNumber);
            Policy policy = new Policy();
            policy.PolicyNumber = data.PolicyId;
            policy.InsuredName = data.InsuredName;

            var docs = GetPolicyDocumentsByPolicyNumber(policyNumber).ToArray();
            policy.Documents = docs;
            var claims = GetPolicyClaimsDocumentsByPolicyNumber(policyNumber).ToArray();
            policy.Claims = claims;


            return policy;
        }

        public Policy GetPolicyNumberByInsuredName(string insuredname)
        {
            var data = _context.PolicyMaster.FirstOrDefault(p => p.InsuredName == insuredname);
            Policy policy = new Policy();
            policy.PolicyNumber = data.PolicyId;
            policy.InsuredName = data.InsuredName;

            var docs = GetPolicyDocumentsByPolicyNumber(policy.PolicyNumber).ToArray();
            policy.Documents = docs;
            var claims = GetPolicyClaimsDocumentsByPolicyNumber(policy.PolicyNumber).ToArray();
            policy.Claims = claims;


            return policy;
        }

        public Policy GetPolicyByClaimId(string claimId)
        {
            var data = _context.ClaimMaster.FirstOrDefault(c => c.ClaimId == claimId);
            Policy policy = new Policy();
            policy.PolicyNumber = data.PolicyId;
            policy.InsuredName = data.InsuredName;

            var docs = GetPolicyDocumentsByPolicyNumber(policy.PolicyNumber).ToArray();
            policy.Documents = docs;
            var claims = GetPolicyClaimsDocumentsByPolicyNumber(policy.PolicyNumber).ToArray();
            policy.Claims = claims;

            return policy;
        }

    }
}
