using System;
using Xunit;
using FluentAssertions;
using PdsLookup;

namespace PdsLookupTests
{

    public class PatientRetreiverTests
    {
        private readonly string _fakePath = "TestFakePatients.json";
        
        [Fact]
        public void GetPatientDetail_WhenCalledWithValidNhsNumber_ReturnsPatient()
        {
            var sut = new PdsRetreiver(_fakePath);

            var result = sut.Retrieve("1234567890");

            result.PatientName.Should().Be("Richard Grayson");
        }

        [Fact]
        public void GetPatientDetail_WhenPatientNotFound_Throws()
        {
            var sut = new PdsRetreiver(_fakePath);

            var ex = Assert.Throws<Exception>(() => sut.Retrieve("1111111111"));

            ex.Message.Should().Be("Nhs number not found");
        }

    }
}
