using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MigrationsApi.PatientDelta;
using PatientDelta;

namespace MigrationsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPatientDeltaRepository _repo;


        public PatientsController(ILogger<PatientsController> logger, IPatientDeltaRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }


        [HttpPost]
        public void AddPatientToTransfers([FromBody] IncomingTransferPatientModel patient)
        {
            try
            {
                _repo.AddPatient(patient);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        [HttpGet]
        public string RetreiveTransferPatients()
        {
            var response = _repo.RetreivePatients();

            return JsonSerializer.Serialize(response);
        }

    }
}