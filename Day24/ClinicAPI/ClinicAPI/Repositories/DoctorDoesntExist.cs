using System.Runtime.Serialization;

namespace ClinicAPI.Repositories
{
    [Serializable]
    internal class DoctorDoesntExist : Exception
    {
        string message;
        public DoctorDoesntExist()
        {
            message = "The Doctor ID is not Valid";
        }
        public override string Message => message;


    }
}