using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SawgrassViewerApi.Models;
using SawgrassViewerApi.Repositories;

namespace SawgrassViewerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyRepository _repo;

        public PolicyController(IPolicyRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Policy
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Policy/5
        
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            var result = _repo.GetInsuredNameByPolicyNumber(id);
            return Ok(result);
        }

        // GET: api/Policy/5
        
        [HttpGet("named/{id}", Name = "GetByName")]
        public IActionResult GetByName(string id)
        {
            var result = _repo.GetPolicyNumberByInsuredName(id);
            return Ok(result);
        }
        
        [HttpPost("document")]
        public IActionResult GetDocument(string id)
        {
            var data = _repo.GetInsuredNameByPolicyNumber(id);
            return Ok(data.Documents);
        }

        // POST: api/Policy
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Policy/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
