using System;
using System.ComponentModel.DataAnnotations;

namespace PatientDelta.PatientDeltaModel
{
    public class Patient
    {
        public string PatientName { get; set; }

        public string Requester { get; set; }

        public string Status { get; set; }

        public DateTime RequestDate { get; set; }

        [Key]
        public string NhsNumber { get; set; }
    }

    public enum Status
    {
        Pending,
        Doing,
        Done
    }

}
