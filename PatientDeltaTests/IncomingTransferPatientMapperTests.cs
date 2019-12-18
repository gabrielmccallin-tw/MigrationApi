using System;
using Xunit;
using PatientDelta;
using PatientDelta.PatientDeltaModel;

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

            result.PatientName.Equals("wibble");
            result.NhsNumber.Equals("1");
            result.Requester.Equals("wobble");
            result.RequestDate.Equals(DateTime.Now.Date);
            result.Status.Equals("Pending");
        }
    }
}
