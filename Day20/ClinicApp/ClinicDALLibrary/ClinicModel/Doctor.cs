using System;
using System.Collections.Generic;

namespace ClinicDALLibrary.ClinicModel
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public int? Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? ServiceYears { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
