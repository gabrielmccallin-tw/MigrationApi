using System;
using System.Collections.Generic;
using System.Linq;

namespace PdsLookup
{
    public interface IPatientRetreiver
    {
        PatientDetail GetPatientDetail(int nhsNumber);
    }

    public class PatientRetreiver: IPatientRetreiver
    {
        private readonly List<PatientDetail> _fakePatients;

        public PatientRetreiver()
        {
            _fakePatients = MakePatients();
        }

        public PatientDetail GetPatientDetail(int nhsNumber)
        {
            return _fakePatients.FirstOrDefault(p => p.NhsNumber == nhsNumber) ??
                throw new Exception(message: "Nhs number not found");
        }

        private List<PatientDetail> MakePatients()
        {
            return new List<PatientDetail>
            {
                new PatientDetail()
                {
                    Name = "Patient One",
                    Practice = "Practice One",
                    Telephone = "07111111111",
                    Email = "patient1@1.com",
                    Dob = new DateTime(1985, 12, 12),
                    NhsNumber = 111111111
                },
                new PatientDetail()
                {
                    Name = "Patient Two",
                    Practice = "Practice One",
                    Telephone = "07222222222",
                    Email = "patient2@2.com",
                    Dob = new DateTime(1984, 11, 11),
                    NhsNumber = 222222222
                },
                new PatientDetail()
                {
                    Name = "Patient Three",
                    Practice = "Practice One",
                    Telephone = "07333333333",
                    Email = "patient3@3.com",
                    Dob = new DateTime(1983, 10, 10),
                    NhsNumber = 333333333
                },
                new PatientDetail()
                {
                    Name = "Patient Four",
                    Practice = "Practice One",
                    Telephone = "07444444444",
                    Email = "patient4@4.com",
                    Dob = new DateTime(1982, 09, 09),
                    NhsNumber = 444444444
                },
                new PatientDetail()
                {
                    Name = "Patient Five",
                    Practice = "Practice One",
                    Telephone = "07555555555",
                    Email = "patient5@5.com",
                    Dob = new DateTime(1980, 07, 07),
                    NhsNumber = 555555555
                },
            };
        }
    }
}
