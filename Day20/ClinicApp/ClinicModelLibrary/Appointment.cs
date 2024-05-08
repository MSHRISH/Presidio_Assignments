using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelLibrary
{
    public class Appointment
    {
        public int AppointmentID {  get; set; }
        public Patient patient { get; set; }
        public Doctor doctor { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }

        
        public Appointment()
        {
            AppointmentID = 0;
            patient = new Patient();
            doctor = new Doctor();
            AppointmentDate = new DateOnly();
            AppointmentTime = new TimeOnly();
        }

        public Appointment(int appointmentid,Patient patient,Doctor doctor,DateOnly appointmentdate,TimeOnly appointmenttime)
        {
            AppointmentID = appointmentid;
            this.patient= patient;
            this.doctor= doctor;
            AppointmentDate= appointmentdate;
            AppointmentTime= appointmenttime;
        }


    }
}
