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
        public async Task<IActionResult> Insert([FromBody] AddressInfoView address)
        {
            try
            {
                var result = await _srv.AddAddressBook(address);

                return Ok(result);
            }
            catch (Exception exc)
            {
                _log.Error(exc, "Exception while inserting a user");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var result = await _srv.DeleteAddressBook(id);

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