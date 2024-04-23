using ClinicDALLibrary;
using ClinicModelLibrary;
using System.Globalization;

namespace RepositoryTest
{
    public class Tests
    {

        IRepository<int, Appointment> _Appointments;
        [SetUp]
        public void Setup()
        {
            _Appointments=new ClinicAppointmentRepository();
        }

        [Test]
        public void TestAddAppointment()
        {
            //Arrange
            DateOnly.TryParseExact("23/04/2024", "dd/MM/yyyy", null, DateTimeStyles.None, out DateOnly date);
            TimeSpan.TryParse("14:30", out TimeSpan timeSpan);
            TimeOnly time = new TimeOnly(timeSpan.Hours, timeSpan.Minutes, 0);
            Appointment appointment = new Appointment(1,"shrish",date,time);

            //Action
            var result=_Appointments.Add(appointment);

            //Assert
            Assert.That(result.AppointmentID, Is.EqualTo(1));
        }
        [Test]
        public void TestRemoveAppointment()
        {
            //Arrange
            DateOnly.TryParseExact("23/04/2024", "dd/MM/yyyy", null, DateTimeStyles.None, out DateOnly date);
            TimeSpan.TryParse("14:30", out TimeSpan timeSpan);
            TimeOnly time = new TimeOnly(timeSpan.Hours, timeSpan.Minutes, 0);
            Appointment appointment = new Appointment(1, "shrish", date, time);

            //Action
            var result = _Appointments.Add(appointment);
            result=_Appointments.Delete(result.AppointmentID);
            var res= _Appointments.GetAll();
            //Assert
            Assert.Null(res);
        }
    }
}