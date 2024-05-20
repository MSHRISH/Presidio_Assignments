using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Execptions
{
    [Serializable]
    internal class UserNotEnabled : Exception
    {

        string message;
        public UserNotEnabled()
        {
            message = "USer Not Enabled by Admin.";

        }
        public override string Message => message;


    }
}