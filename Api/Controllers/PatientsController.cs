using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientDelta;
using PatientDelta.PatientDeltaModel;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IDeltaOrchestrator _repo;
        
        public PatientsController(ILogger<PatientsController> logger, IDeltaOrchestrator repo)
        {
            _logger = logger;
            _repo = repo;
        }


        [HttpPost]
        public string AddPatientToTransfers([FromBody] IncomingTransferPatientModel patient)
        {
            try
            {
                return _repo.AddPatient(patient);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        [HttpGet]
        public string RetrieveTransferPatients()
        {
            try
            {
                var response = _repo.RetrievePatients();

                return JsonSerializer.Serialize(response);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }
    }
}