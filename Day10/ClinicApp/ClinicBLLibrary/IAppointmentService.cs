using ClinicModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBLLibrary
{
    public interface IAppointmentService
    {
        bool AppointmentClash(Appointment appointment);
        Appointment MakeAppointment(Appointment appointment);
        Appointment GetAppointment(int AppointmentId);
        Appointment UpdateAppointment(Appointment appointment);
        Appointment DeleteAppointment(int AppointmentId);

    }
}
