using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Models.Repository;

namespace webAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IDataRepository<Users> _dataRepository;

        public UserController(IDataRepository<Users> dataRepository)
        {
            _dataRepository = dataRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Users> users = _dataRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Users user = _dataRepository.Get(id);

            if (user == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            _dataRepository.Add(user);
            return CreatedAtRoute(
                  "Get",
                  new { Id = user.ID },
                  user);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            Users userToUpdate = _dataRepository.Get(id);
            if (userToUpdate == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            _dataRepository.Update(userToUpdate, user);
            return NoContent();
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Users user = _dataRepository.Get(id);
            if (user == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            _dataRepository.Delete(user);
            return NoContent();
        }


    }
}