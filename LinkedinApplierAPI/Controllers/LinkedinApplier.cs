using LinkedinJAASerial;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LinkedinApplierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkedinApplier : ControllerBase
    {
        // GET: api/<LinkedinApplier>
        [HttpGet]
        public IEnumerable<LicenceTable> Get()
        {
            return DatabaseConnector.RetrieveLicenceTables();
        }

        // GET: api/<LinkedinApplier>/email/{email}
        [HttpGet("email/{email}")]
        public LicenceTable GetLicenceTableByEmail(string email)
        {
            return DatabaseConnector.GetLicenceTableByEmail(email);
        }   

        // GET: api/<LinkedinApplier>/serialkey/{serialkey}
        [HttpGet("serialkey/{serialkey}")]
        public LicenceTable GetLicenceTableBySerialKey(string serialkey)
        {
            bool isConnectionOK = true;
            return DatabaseConnector.GetLicenceTableBySerialKey(serialkey, ref isConnectionOK);
        }

        // GET: api/<LinkedinApplier>/search/email/{email}
        [HttpGet("search/email/{email}")]
        public IEnumerable<LicenceTable> SearchLicenceTableByEmail(string email)
        {
            return DatabaseConnector.SearchLicenceTableByEmail(email);
        }

        // GET: api/<LinkedinApplier>/search/serialkey/{serialkey}
        [HttpGet("search/serialkey/{serialkey}")]
        public IEnumerable<LicenceTable> SearchLicenceTableBySerialKey(string serialkey)
        {
            return DatabaseConnector.SearchLicenceTableBySerialKey(serialkey);
        }

        // GET: api/<LinkedinApplier>/totalactive
        [HttpGet("totalactive")]
        public int GetTotalActiveLicences()
        {
            return DatabaseConnector.GetTotalActiveLicences();
        }

        // GET: api/<LinkedinApplier>/totaldeleted
        [HttpGet("totaldeleted")]
        public int GetTotalDeletedLicences()
        {
            return DatabaseConnector.GetTotalDeletedLicences();
        }

        // POST: api/<LinkedinApplier>
        [HttpPost]
        public IActionResult Post([FromBody] LicenceTable licenceTable)
        {
            if (licenceTable == null)
            {
                return BadRequest();
            }

            bool success = DatabaseConnector.InsertLicenceTable(licenceTable);

            if (success)
            {
                return Ok();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while inserting LicenceTable.");
            }
        }

        // PUT: api/<LinkedinApplier>/update
        [HttpPut("update")]
        public IActionResult UpdateLicenceTable([FromBody] LicenceTable licenceTable)
        {
            if (licenceTable == null)
            {
                return BadRequest();
            }

            
            DatabaseConnector.UpdateLicenceTable(licenceTable);
            return Ok();
        }

        // DELETE: api/<LinkedinApplier>/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteLicenceTable(int id)
        {
           
            DatabaseConnector.DeleteLicenceTable(id);
            return Ok();
        }

        // PUT: api/<LinkedinApplier>/status/{id}/{isOnline}
        [HttpPut("status/{id}/{isOnline}")]
        public IActionResult UpdateLicenceTableOnlineStatus(int id, bool isOnline)
        {
            
            DatabaseConnector.UpdateLicenceTableOnlineStatus(id, isOnline);
            return Ok();
        }

        // GET: api/<LinkedinApplier>/macaddress/{id}
        [HttpGet("macaddress/{id}")]
        public IActionResult GetMacAddressById(int id)
        {
            string macAddress = DatabaseConnector.GetMacAddressById(id);

            if (macAddress == null)
            {
                return NotFound();
            }

            return Ok(macAddress);
        }

        // PUT: api/<LinkedinApplier>/macaddress/{id}
        [HttpPut("macaddress/{id}")]
        public IActionResult SetMacAddressById(int id, string macAddress)
        {
            
            DatabaseConnector.SetMacAddressById(id, macAddress);
            return Ok();
        }

    }
}
