using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taxrun_API_new.Databases;
using taxrun_API_new.Models;

namespace taxrun_API_new.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MandateUserController : ControllerBase
    {
        private MandateUserContext _mandateUserContext;

        public MandateUserController(MandateUserContext mandateUserContext)
        {
            _mandateUserContext = mandateUserContext;
        }

        // GET: api/Quote
        [HttpGet]
        public IEnumerable<MandateUser> Get()
        {
            return _mandateUserContext.MandateUsers;
        }

        // GET: api/Quote/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {

            return "value";
        }

        // POST: api/Quote
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Quote/5
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
