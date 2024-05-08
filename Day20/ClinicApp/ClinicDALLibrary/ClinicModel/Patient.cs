using System;
using System.Collections.Generic;

namespace ClinicDALLibrary.ClinicModel
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
