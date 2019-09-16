using System;
using AddressBook.Api.Services;
using AddressBook.Api.Views;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AddressBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressInfoController : ControllerBase
    {
        private readonly ILogger _log;
        private readonly IAddressInfoService _srv;

        public AddressInfoController(IAddressInfoService srv, ILogger log)
        {
            _srv = srv;
            _log = log;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] AddressInfoView address)
        {
            try
            {
                var result = _srv.AddAddressBook(address);

                return Ok(result);
            }
            catch (Exception exc)
            {
                _log.Error(exc, "Exception while inserting an Address");

                return BadRequest("Failed to add an Address");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var result = _srv.DeleteAddressBook(id);

                return Ok(result);
            }
            catch (Exception exc)
            {
                _log.Error(exc, "Exception inserting attendance for Athlete with Id {@athleteId}");
                
                return BadRequest("Error while deleting the selected Address");
            }
        }
    }
}