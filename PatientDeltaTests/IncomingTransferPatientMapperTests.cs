using System;
using Xunit;
using PatientDelta;
using MigrationsApi.PatientDelta;

namespace PatientDeltaTests
{
    public class IncomingTransferPatientMapperTests
    {
        [Fact]
        public void Map_WhenProvidedWithLegitIncomingPatient_MapsToPatient()
        {
            var testTransfer = new IncomingTransferPatientModel()
            {
                NhsNumber = "1",
                PatientName = "wibble",
                Ods = "blah",
                Requester = "wobble"
            };

            var sut = new IncomingTransferPatientMapper();

            var result = sut.Map(testTransfer);

            result.Name.Equals("wibble");
            result.NhsNumber.Equals(1);
        }
    }
}
