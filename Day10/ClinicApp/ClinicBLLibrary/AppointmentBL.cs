using ClinicDALLibrary;
using ClinicModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBLLibrary
{
    public class AppointmentBL:IAppointmentService
    {
        IRepository<int, Appointment> _Appointments;

        public AppointmentBL(IRepository<int, Appointment> appointmentrepo)
        {
            _Appointments = appointmentrepo;
        }

        public bool AppointmentClash(Appointment appointment)
        {
            var AllAppointments=_Appointments.GetAll();
            if (AllAppointments == null)
            {
                return false;
            }

            foreach(var item in AllAppointments)
            {
                if(item.AppointmentTime==appointment.AppointmentTime && item.AppointmentDate==appointment.AppointmentDate && item.DoctorName==appointment.DoctorName)
                {
                    return true;                
                }
            }
            //return _appointments.Values.Any(a => a.AppointmentTime == appointment.AppointmentTime && a.doctor.DoctorId == appointment.doctor.DoctorId);

            return false;
        }
        public Appointment MakeAppointment(Appointment appointment)
        {
            if(!AppointmentClash(appointment))
            {
                return _Appointments.Add(appointment);
            }

            return null;
        }

        public Appointment GetAppointment(int AppointmentId)
        {
            return _Appointments.Get(AppointmentId);
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            if (!AppointmentClash(appointment))
            {
                return _Appointments.Update(appointment);
            }
            return null;
        }

        public Appointment DeleteAppointment(int AppointmentId)
        {
            return _Appointments.Delete(AppointmentId);
        }
        
    }
}
