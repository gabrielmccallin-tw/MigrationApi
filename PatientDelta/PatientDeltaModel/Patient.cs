using System;
using System.ComponentModel.DataAnnotations;

namespace PatientDelta
{
    public class Patient
    {
        public string Name { get; set; }

        public string Practice { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public DateTime Dob { get; set; }

        [Key]
        public int NhsNumber { get; set; }
    }
}
