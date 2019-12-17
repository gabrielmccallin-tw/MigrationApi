using System.Collections.Generic;
using PatientDelta.PatientDeltaModel;

namespace PatientDelta
{
    public interface IDeltaOrchestrator
    {
        string AddPatient(IncomingTransferPatientModel patient);

        List<Patient> RetrievePatients();
    }
}
