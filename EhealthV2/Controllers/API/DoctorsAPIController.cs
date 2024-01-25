using EhealthV2.Models.Users;
using EhealthV2.Repositories.Users;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Numerics;

namespace EHealth.Controllers.Api
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsApiController : ControllerBase
    {
        private readonly IDoctorsController _docdata;
        private readonly IClinicsController _clidata;
        public DoctorsApiController(IDoctorsController docdata)
        {
            _docdata = docdata ?? throw new ArgumentNullException(nameof(docdata));
        }

        [HttpGet]
        public ActionResult<List<Doctors>> GetAll()
        {
            List<Doctors> doctors = _docdata.DoctorsInitData();

            if (doctors == null || doctors.Count == 0)
            {
                // Return 404 Not Found if no doctors are found
                return NotFound("No doctors found.");
            }

            return Ok(doctors);
        }

        [HttpGet("/api/Clinics")]
        public string getClinic()
        {
            string test = _clidata.getJsonFromEclipse();
            return test;
        }
    }
}
