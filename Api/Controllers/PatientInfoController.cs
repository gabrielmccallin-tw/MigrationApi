using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PdsLookup;
using PdsLookup.PdsModels;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientInfoController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPdsRetreiver _pdsRetreiver;

        public PatientInfoController(ILogger<PatientInfoController> logger, IPdsRetreiver pdsRetreiver)
        {
            _logger = logger;
            _pdsRetreiver = pdsRetreiver;
        }

        [HttpGet("{id}")]
        public PatientDetail GetPatientDetail(string id)
        {
            return _pdsRetreiver.Retrieve(Int32.Parse(id));
        }
    }
}