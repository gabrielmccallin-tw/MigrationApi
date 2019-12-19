using System;

namespace PdsLookup.PdsModels
{
    public class PatientDetail
    {
        public string PatientName { get; set; }

        public string Practice { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public DateTime Dob { get; set; }

        public string NhsNumber { get; set; }
    }
}
