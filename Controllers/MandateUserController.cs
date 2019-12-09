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

        // GET: api/MandateUser
        [HttpGet]
        public IActionResult Get(string sort)
        {
            IQueryable<MandateUser> mandateUser;

            switch (sort)
            {
                case "desc":
                    mandateUser = _mandateUserContext.MandateUsers.OrderByDescending(x => x.UserGroupID);
                    break;
                case "asc":
                    mandateUser = _mandateUserContext.MandateUsers.OrderBy(x => x.UserGroupID);
                    break;
                default:
                    mandateUser = _mandateUserContext.MandateUsers;
                    break;
            }

            return Ok(mandateUser);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult PagingMandateUser(int? pageNumber, int? pageSize)
        {
            var mandateUser = _mandateUserContext.MandateUsers;
            var currentPageNumber = pageNumber ?? 1;
            var currentPageSize = pageSize ?? 4;

            return Ok(mandateUser.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize));
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult SearchMandateUser(int userGroupID)
        {
            var mandateUser = _mandateUserContext.MandateUsers.Where(x => x.UserGroupID.Equals(userGroupID));
            return Ok(mandateUser);
        }

        // GET: api/MandateUser/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {          
            var mandateUser = _mandateUserContext.MandateUsers.Find(id);

            if (mandateUser == null)
            {
                return NotFound("Record not found");
            }
            else
            {
                return Ok(mandateUser);
            }         
        }

        //api/MandateUser/Test/1
        [HttpGet("[action]/{id}")]
        public int Test(int id)
        {
            return id;
        }

        // POST: api/MandateUser
        [HttpPost]
        public IActionResult Post([FromBody] MandateUser mandateUser)
        {
            _mandateUserContext.MandateUsers.Add(mandateUser);
            //_mandateUserContext.SaveChanges(); -- Saves changes to the database

            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Quote/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MandateUser mandateUser)
        {
            var entity = _mandateUserContext.MandateUsers.Find(id);

            if (entity == null)
            {
                return NotFound("Record not found");
            }
            else
            {
                entity.Name = mandateUser.Name;
                entity.UPN = mandateUser.UPN;
                entity.UserGroupID = mandateUser.UserGroupID;
                //_mandateUserContext.SaveChanges();

                return Ok("Record updated successfully");
            }          
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var mandateUser = _mandateUserContext.MandateUsers.Find(id);

            if (mandateUser == null)
            {
                return NotFound("Record not found");
            }
            else
            {
                _mandateUserContext.MandateUsers.Remove(mandateUser);
                //_mandateUserContext.SaveChanges();

                return Ok("Record deleted");
            }             
        }
    }
}
