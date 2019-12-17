using System.Collections.Generic;
using MigrationsApi.PatientDelta;

namespace PatientDelta
{
    public interface IPatientDeltaRepository
    {
        void AddPatient(IncomingTransferPatientModel patient);

        List<Patient> RetreivePatients();
    }
}
