using System;
using MigrationsApi.PatientDelta;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientDelta
{

    public class PatientDeltaRepository : IPatientDeltaRepository
    {
        private readonly PatientsContext _context;
        private readonly IIncomingTransferPatientMapper _mapper;

        public PatientDeltaRepository(PatientsContext context, IIncomingTransferPatientMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddPatient(IncomingTransferPatientModel patient)
        {
            if (_context.Patients.Any(p => p.NhsNumber == Int32.Parse(patient.NhsNumber)))
            {
                return;
            }
            
            _context.Add(_mapper.Map(patient));
            _context.SaveChanges();
        }

        public List<Patient> RetreivePatients()
        {
            return _context.Patients.OrderBy(p => p.Name).ToList();
        }
    }
}