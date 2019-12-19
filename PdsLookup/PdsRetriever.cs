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
        private readonly string _optPath;
        private readonly string _fakePatientPath = "..//PdsLookup//Data//FakePatients.json";

        public PdsRetreiver(string optPath = null)
        {
            _optPath = optPath;
            _fakePatients = MakePatients();
        }

        public PatientDetail Retrieve(string nhsNumber)
        {
            return _fakePatients.FirstOrDefault(p => p.NhsNumber == nhsNumber) ??
                throw new Exception(message: "Nhs number not found");
        }

        private List<PatientDetail> MakePatients()
        {
            
            var patients = JsonConvert.DeserializeObject<List<PatientDetail>>(File.ReadAllText(_optPath ?? _fakePatientPath));
            return patients;
        }
    }
}
