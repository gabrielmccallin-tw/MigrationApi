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
        private readonly IPdsRetreiver _pdsRetriever;

        public PatientInfoController(ILogger<PatientInfoController> logger, IPdsRetreiver pdsRetriever)
        {
            _logger = logger;
            _pdsRetriever = pdsRetriever;
        }

        [HttpGet("{id}")]
        public PatientDetail GetPatientDetail(string id)
        {
            return _pdsRetriever.Retrieve(id);
        }
    }
}