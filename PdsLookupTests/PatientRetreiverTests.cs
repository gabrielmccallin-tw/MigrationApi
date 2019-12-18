using System;
using Xunit;
using FluentAssertions;
using PdsLookup;

namespace PdsLookupTests
{

    public class PatientRetreiverTests
    {
        [Fact]
        public void GetPatientDetail_WhenCalledWithValidNhsNumber_ReturnsPatient()
        {
            var sut = new PdsRetreiver();

            var result = sut.Retrieve(111111111);

            result.PatientName.Should().Be("Patient One");
        }

        [Fact]
        public void GetPatientDetail_WhenPatientNotFound_Throws()
        {
            var sut = new PdsRetreiver();

            var ex = Assert.Throws<Exception>(() => sut.Retrieve(123456789));

            ex.Message.Should().Be("Nhs number not found");
        }

    }
}
