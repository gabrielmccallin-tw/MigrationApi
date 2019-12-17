using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PdsLookup;
using PdsLookup.PdsModels;

namespace MigrationsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientInfoController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPatientRetreiver _patientRetreiver;

        public PatientInfoController(ILogger<PatientInfoController> logger, IPatientRetreiver patientRetreiver)
        {
            _logger = logger;
            _patientRetreiver = patientRetreiver;
        }

        [HttpGet]
        public PatientDetail GetPatientDetail([FromBody] NhsNumberModel nhsNumberModel)
        {
            return _patientRetreiver.GetPatientDetail(nhsNumberModel.NhsNumber);
        }
    }
}