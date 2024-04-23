using ClinicDALLibrary;
using ClinicModelLibrary;
using ClinicBLLibrary;
using System.Globalization;
namespace BusinessLogicTest
{
    public class Tests
    {
        IRepository<int, Appointment> _Appointments;
        IAppointmentService _AppointmentService;
        [SetUp]
        public void Setup()
        {
            _Appointments = new ClinicAppointmentRepository();
            _AppointmentService=new AppointmentBL(_Appointments);
        }

        [Test]
        public void AddApointmentBL()
        {
            //Arrange
            DateOnly.TryParseExact("23/04/2024", "dd/MM/yyyy", null, DateTimeStyles.None, out DateOnly date);
            TimeSpan.TryParse("14:30", out TimeSpan timeSpan);
            TimeOnly time = new TimeOnly(timeSpan.Hours, timeSpan.Minutes, 0);
            Appointment appointment = new Appointment(1, "shrish", date, time);

            //Action
            var result=_AppointmentService.MakeAppointment(appointment);

            Assert.That(result.AppointmentID, Is.EqualTo(1));
        }

        [Test]

    }
}