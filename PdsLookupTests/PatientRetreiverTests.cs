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
            var sut = new PatientRetreiver();

            var result = sut.GetPatientDetail(111111111);

            result.Name.Should().Be("Patient One");
        }

        [Fact]
        public void GetPatientDetail_WhenPatientNotFound_Throws()
        {
            var sut = new PatientRetreiver();

            var ex = Assert.Throws<Exception>(() => sut.GetPatientDetail(123456789));

            ex.Message.Should().Be("Nhs number not found");
        }

    }
}
