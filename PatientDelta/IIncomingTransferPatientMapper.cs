using PatientDelta.PatientDeltaModel;

namespace PatientDelta
{
    public interface IIncomingTransferPatientMapper
    {
        Patient Map(IncomingTransferPatientModel patient);
    }
}
