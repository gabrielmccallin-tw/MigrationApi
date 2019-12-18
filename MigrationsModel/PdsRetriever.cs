using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PdsLookup.PdsModels;

namespace PdsLookup
{
    public class PdsRetreiver: IPdsRetreiver
    {
        private readonly List<PatientDetail> _fakePatients;
        private readonly string _fakePatientPath = "..//MigrationsModel//Data//FakePatients.json";

        public PdsRetreiver()
        {
            _fakePatients = MakePatients();
        }

        public PatientDetail Retrieve(int nhsNumber)
        {
            return _fakePatients.FirstOrDefault(p => Int64.Parse(p.NhsNumber) == nhsNumber) ??
                throw new Exception(message: "Nhs number not found");
        }

        private List<PatientDetail> MakePatients()
        {
            var patients = JsonConvert.DeserializeObject<List<PatientDetail>>(File.ReadAllText(_fakePatientPath));
            return patients;
        }
    }
}
