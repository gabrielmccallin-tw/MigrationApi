using MigrationsApi.PatientDelta;

namespace PatientDelta
{
    public interface IIncomingTransferPatientMapper
    {
        Patient Map(IncomingTransferPatientModel patient);
    }
}
