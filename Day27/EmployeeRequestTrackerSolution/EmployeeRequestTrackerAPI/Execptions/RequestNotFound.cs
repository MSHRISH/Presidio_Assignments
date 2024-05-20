using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Execptions
{
    [Serializable]
    internal class RequestNotFound : Exception
    {
        string message;
        public RequestNotFound()
        {
            message = "No such Request Exists";
        }
        public override string Message => message;

    }
}