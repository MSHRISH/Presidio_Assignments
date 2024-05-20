using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Execptions
{
    [Serializable]
    internal class NoSuchEmployeeExecption : Exception
    {
        string message;
        public NoSuchEmployeeExecption()
        {
            message = "No such Employee Exists";
        }
        public override string Message => message;
    }
}