using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelLibrary
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }

        public string DoctorName { get; set; }=string.Empty;
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }

        
        public Appointment()
        {
            AppointmentID = 0;
            AppointmentDate = new DateOnly();
            AppointmentTime = new TimeOnly();
        }

        public Appointment(int patientid,string doctorname,DateOnly appointmentdate,TimeOnly appointmenttime)
        {
            PatientID = patientid;
            DoctorName = doctorname;
            AppointmentDate= appointmentdate;
            AppointmentTime= appointmenttime;
        }


    }
}
