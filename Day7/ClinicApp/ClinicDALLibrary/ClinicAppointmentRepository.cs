using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary;

namespace ClinicDALLibrary
{
    public class ClinicAppointmentRepository : IRepository<int, Appointment>
    {
        readonly Dictionary<int, Appointment> _appointments;
        public ClinicAppointmentRepository()
        {
            _appointments = new Dictionary<int, Appointment>();
        }
        int GenerateId()
        {
            if (_appointments.Count == 0)
                return 1;
            int id = _appointments.Keys.Max();
            return ++id;
        }
        public bool AppointmentExists(Appointment appointment)
        {

            return _appointments.Values.Any(a=> a.AppointmentTime==appointment.AppointmentTime && a.doctor.DoctorId==appointment.doctor.DoctorId);
        }
        public Appointment AddAppointment(Appointment appointment)
        {
            if (AppointmentExists(appointment))
            {
                return null;    
            }
            _appointments.Add(GenerateId(), appointment);
            return appointment;

        }
        public List<Appointment> GetAllAppointments()
        {
            if (_appointments.Count == 0)
                return null;
            return _appointments.Values.ToList();
        }
        public Appointment GetAppointment(int key)
        {
            return _appointments.ContainsKey(key) ? _appointments[key] : null;
        }
        public Appointment DeleteAppointment(int key)
        {
            if (_appointments.ContainsKey(key))
            {
                var department = _appointments[key];
                _appointments.Remove(key);
                return department;
            }
            return null;
        }    


        public Appointment UpdateAppointment(Appointment appointment)
        {
            if (_appointments.ContainsKey(appointment.AppointmentID))
            {
                _appointments[appointment.AppointmentID] = appointment;
                return appointment;
            }
            return null;
        }
    }
}
