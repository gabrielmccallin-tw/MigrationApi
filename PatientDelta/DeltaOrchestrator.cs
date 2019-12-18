using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using PatientDelta.PatientDeltaModel;

namespace PatientDelta
{
    public class DeltaOrchestrator : IDeltaOrchestrator
    {
        private readonly PatientsContext _context;
        private readonly IIncomingTransferPatientMapper _mapper;

        public DeltaOrchestrator(PatientsContext context, IIncomingTransferPatientMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _context.Database.EnsureCreated(); 
            // change above to Migrate instead of Ensure created if you see errors
            // related to 'Table already exists' or 'table not found'. I have no 
            // idea why. 
        }

        public string AddPatient(IncomingTransferPatientModel patient)
        {
       
            if (_context.Patients.Any(p => p.NhsNumber == patient.NhsNumber))
            {
                return "Patient already queued for transfer";
            }

            var mappedPatient = _mapper.Map(patient);
            _context.Add(mappedPatient);
            _context.SaveChanges();

            return JsonSerializer.Serialize(mappedPatient);
        }

        public List<Patient> RetrievePatients()
        {
            return _context.Patients.OrderBy(p => p.PatientName).ToList();
        }

        public string RemovePatients()
        {
            var collectionToDelete = _context.Patients;
            _context.Patients.RemoveRange(collectionToDelete);
            _context.SaveChanges();

            return !_context.Patients.Any() ? 
                "patients cleared" : 
                "couldn't clear patients";
        }
    }
}