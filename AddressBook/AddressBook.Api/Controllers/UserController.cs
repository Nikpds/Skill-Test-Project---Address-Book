using System;
using System.Threading.Tasks;
using AddressBook.Api.Services;
using AddressBook.Api.Views;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AddressBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger _log;
        private readonly IUserService _srv;
        // TO DO VALIDATION
        public UserController(IUserService srv, ILogger log)
        {
            _srv = srv;
            _log = log;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UserView user)
        {
            try
            {
                var result = await _srv.AddUser(user);

                return Ok(result);
            }
            catch (Exception exc)
            {
                _log.Error(exc, "Exception while inserting a user");
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UserView user, string id)
        {
            try
            {
                var result = await _srv.UpdateUser(user);

                return Ok(result);
            }
            catch (Exception exc)
            {
                _log.Error(exc, "Exception inserting attendance for Athlete with Id {@athleteId}");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var result = await _srv.DeleteUser(id);

                return Ok(result);
            }
            catch (Exception exc)
            {
                _log.Error(exc, "Exception inserting attendance for Athlete with Id {@athleteId}");
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var result = await _srv.GetUser(id);

                return Ok(result);
            }
            catch (Exception exc)
            {
                _log.Error(exc, "Exception inserting attendance for Athlete with Id {@athleteId}");
                return BadRequest();
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _srv.GetUsers();

                return Ok(result);
            }
            catch (Exception exc)
            {
                _log.Error(exc, "Exception inserting attendance for Athlete with Id {@athleteId}");
                return BadRequest();
            }
        }
    }
}