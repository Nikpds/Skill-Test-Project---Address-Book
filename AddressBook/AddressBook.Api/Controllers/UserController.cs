using System;
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

        public UserController(IUserService srv, ILogger log)
        {
            _srv = srv;
            _log = log;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] UserView user)
        {
            try
            {
                if (!user.IsValid())
                {
                    return BadRequest();
                }

                var result = _srv.AddUser(user);

                return Ok(result);
            }
            catch (Exception exc)
            {
                _log.Error(exc, "Exception while inserting a user");
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UserView user, string id)
        {
            try
            {
                if (!user.IsValid())
                {
                    return BadRequest();
                }

                var result = _srv.UpdateUser(user);

                return Ok(result);
            }
            catch (Exception exc)
            {
                _log.Error(exc, "Exception updating user with id: {@id}", id);
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest();
                }

                var result = _srv.DeleteUser(id);

                return Ok(result);
            }
            catch (Exception exc)
            {
                _log.Error(exc, "Exception deleting user with id: {@id}", id);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest();
                }

                var result = _srv.GetUser(id);

                return Ok(result);
            }
            catch (Exception exc)
            {
                _log.Error(exc, "Exception getting user with id: {@id}", id);

                return BadRequest();
            }
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _srv.GetUsers();

                return Ok(result);
            }
            catch (Exception exc)
            {
                _log.Error(exc, "Exception getting users");

                return BadRequest();
            }
        }
    }
}