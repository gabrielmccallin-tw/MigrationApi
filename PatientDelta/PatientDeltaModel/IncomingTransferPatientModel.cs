using System;

namespace MigrationsApi.PatientDelta
{
    public class IncomingTransferPatientModel
    {
        public string Ods { get; set; }

        public string PatientName { get; set; }

        public string NhsNumber { get; set; }

        public string Requester { get; set; }
    }
}

