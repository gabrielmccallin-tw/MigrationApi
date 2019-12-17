using System;
using MigrationsApi.PatientDelta;

namespace PatientDelta
{
    public class IncomingTransferPatientMapper : IIncomingTransferPatientMapper
    {
        public Patient Map(IncomingTransferPatientModel patient)
        {
            return new Patient()
            {
                Name = patient.PatientName,
                NhsNumber = Int32.Parse(patient.NhsNumber)
            };
        }
    }
}
